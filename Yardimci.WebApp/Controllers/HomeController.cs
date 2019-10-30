using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Yardimci.BusinessLayer;
using Yardimci.BusinessLayer.Results;
using Yardimci.Entities;
using Yardimci.Entities.Message;
using Yardimci.Entities.Messages;
using Yardimci.Entities.ValueObjects;
using Yardimci.WebApp.ViewModels;

namespace Yardimci.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private CalisanlarManager cm = new CalisanlarManager();
        private HizmetlerManager hm = new HizmetlerManager();
        private YardimciKullaniciManager ykm = new YardimciKullaniciManager();


        // GET: Home
        public ActionResult Index()
        {

            
            return View(cm.List());

        }

        public ActionResult ByHizmetler(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            Hizmetler hiz = hm.Find(x => x.ID == id.Value);



            if (hiz == null)
            {
                return HttpNotFound();
            }



            return View("Index", hiz.calisan);
        }

        public ActionResult MostLiked()
        {
            

            return View("Index",cm.ListQueryable().OrderByDescending(x => x.Liked.Count).ToList());
        }

        public ActionResult Ekonomik()
        {
            

            return View("Index", cm.ListQueryable().OrderBy(x => x.SaatlikUcret).ToList());
        }
        public ActionResult About()
        {
            
            return View("About");
        }


        public ActionResult ShowProfile()
        {
            Kullanici currentUser = Session["login"] as Kullanici;

            
            BusinessLayerResult<Kullanici> res = ykm.GetUserById(currentUser.ID);

            if(res.Errors.Count > 0)
            {
                ErrorViewModel errornotifyObj = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    Items = res.Errors
                };

                return View("Error", errornotifyObj);
            }

            return View(res.Result);
        }

        public ActionResult ShowProfile2()
        {
            Kullanici currentUser = Session["login"] as Kullanici;

            
            BusinessLayerResult<Kullanici> res = ykm.GetUserById(currentUser.ID);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel errornotifyObj = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    Items = res.Errors
                };

                return View("Error", errornotifyObj);
            }

            return View(res.Result);
        }



        public ActionResult EditProfile()
        {
            Kullanici currentUser = Session["login"] as Kullanici;

            
            BusinessLayerResult<Kullanici> res = ykm.GetUserById(currentUser.ID);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel errornotifyObj = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    Items = res.Errors
                };

                return View("Error", errornotifyObj);
            }

            return View(res.Result);
        }

        


        [HttpPost]
        public ActionResult EditProfile(Kullanici model, HttpPostedFileBase ProfileImage)
        {
            //Kontrol edilmesini istemediğim valid değerlerinin ModelState içinden siliyorum.
            ModelState.Remove("TelefonNo");
            ModelState.Remove("KullaniciAdi");
            ModelState.Remove("Email");
            ModelState.Remove("DegistirenKullanici");


            if (ModelState.IsValid)
            {
                if (ProfileImage != null &&
                (ProfileImage.ContentType == "image/jpeg" ||
                ProfileImage.ContentType == "image/jpg" ||
                ProfileImage.ContentType == "image/png"))
                {
                    string filename = $"user_{model.ID}.{ProfileImage.ContentType.Split('/')[1]}";

                    ProfileImage.SaveAs(Server.MapPath($"~/images/{filename}"));
                    model.ProfileImageFileName = filename;
                }


                
                BusinessLayerResult<Kullanici> res = ykm.UpdateProfile(model);

                if (res.Errors.Count > 0)
                {
                    ErrorViewModel errorNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Profil güncellenemedi !",
                        RedirectingUrl = "/Home/EditProfile"

                    };
                    return View("Error", errorNotifyObj);
                }
                Session["login"] = res.Result; // Profil güncellendiği için sessionu güncelledik.

                return RedirectToAction("ShowProfile");

            }
            return View(model);
            
        }

        public ActionResult DeleteProfile(Kullanici user)
        {
            Kullanici currentUser = Session["login"] as Kullanici;

            
            BusinessLayerResult<Kullanici> res = ykm.RemoveUserById(currentUser.ID);

            if(res.Errors.Count > 0)
            {
                ErrorViewModel errorNotifyobj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Profil Silinemedi",
                    RedirectingUrl ="/Home/ShowProfile"
                };

                return View("Error", errorNotifyobj);
            }
            Session.Clear();

            return RedirectToAction("Index");
        }





        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

 
            if (ModelState.IsValid)
            {
                
                BusinessLayerResult<Kullanici> res = ykm.LoginUser(model);

                if (res.Errors.Count > 0)
                {
                    if (res.Errors.Find(x => x.Code == ErrorMessageCode.UserIsNoteActive) != null)
                    {
                        ViewBag.SetLink = "http://denemeneme";
                    }

                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }


                Session["login"] = res.Result;       //Sessionda bilgi saklama

                return RedirectToAction("Index");    //Yönlendirme


            }
            return View(model);
        }

        public ActionResult Register()
        {


            return View();

        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {

            if(ModelState.IsValid)
            {
                
                
                BusinessLayerResult<Kullanici> res = ykm.RegisterUser(model);
                
                
                if(res.Errors.Count>0)
                {
                    res.Errors.ForEach(x =>  ModelState.AddModelError("", x.Message));

                    return View(model);
                }
                Session["register"] = res.Result;       //Sessionda bilgi saklama

                OkViewModel notifyObj = new OkViewModel()
                {
                    Title = "Kayıt Başarılı",
                    RedirectingUrl = "/Home/Login",

                };
                notifyObj.Items.Add("Hizmetlerimizden yararlanmak için lütfen mailinize gelen aktivasyon linkine tıklayınız.");

                return View("Ok",notifyObj);
            }

            return View(model);

        }

        
        public ActionResult KullaniciAktif(Guid id)
        {
            
            BusinessLayerResult<Kullanici> res =  ykm.ActivateUser(id);

            if(res.Errors.Count >0)
            {
                ErrorViewModel errornotifyObj = new ErrorViewModel()
                {
                    Title = "Geçersiz İşlem",
                    Items = res.Errors
                };
                
                return View("Error",errornotifyObj);
            }
            //deneme
            //res.Result.AktifMi = true;
            OkViewModel oknotifyObj = new OkViewModel()
            {
                Title = "Hesabınız aktifleştirilmiştir.",
                RedirectingUrl ="/Home/Login"
 
            };
            oknotifyObj.Items.Add("Hesabınız aktifleştirilmiştir. Hizmetlerimizden yararlanabilir ve hizmet verebilirsiniz");

            return View("Ok",oknotifyObj);


        }

       

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");

        }
    }
}