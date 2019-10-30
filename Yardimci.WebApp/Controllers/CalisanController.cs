using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Yardimci.BusinessLayer;
using Yardimci.BusinessLayer.Results;
using Yardimci.Entities;
using Yardimci.WebApp.Models;

namespace Yardimci.WebApp.Controllers
{
    public class CalisanController : Controller
    {

        private YardimciCalisanManager yardimciCalisanManager  = new YardimciCalisanManager();

        private LikedManager likedManager = new LikedManager();


        public ActionResult Index()
        {
           
            return View(yardimciCalisanManager.List());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisan calisan = yardimciCalisanManager.Find(x => x.ID == id.Value);
            if (calisan == null)
            {
                return HttpNotFound();
            }
            return View(calisan);
        }

        
        public ActionResult Create()
        {
            return View();
        }

       /* public ActionResult MyLikedCalisan()
        {
            var calisan = likedManager.ListQueryable().Include("LikedKullanici").Include("LikedCalisan").Where(x => x.LikedKullanici.ID == CurrentSession.User.ID).Select(x => x.LikedCalisan).Include("Hizmetler").OrderByDescending(x => x.DegistirilmeZamani);

            return View("Index",calisan.ToList());

        } */


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Calisan calisan)
        {
            ModelState.Remove("OlusturulmaZamani");
            ModelState.Remove("DegistirilmeZamani ");
            ModelState.Remove("DegistirenKullanici");
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Calisan> res = yardimciCalisanManager.Insert(calisan);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    return View(calisan);
                }

                return RedirectToAction("Index");
            }

            return View(calisan);
        }

        
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisan calisan = yardimciCalisanManager.Find(x =>x.ID == id.Value);
            if (calisan == null)
            {
                return HttpNotFound();
            }
            return View(calisan);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Calisan calisan)
        {
            ModelState.Remove("OlusturulmaZamani");
            ModelState.Remove("DegistirilmeZamani ");
            ModelState.Remove("DegistirenKullanici");
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Calisan> res = yardimciCalisanManager.Update(calisan);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    return View(calisan);
                }
                return RedirectToAction("Index");
            }
            return View(calisan); ;
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisan calisan = yardimciCalisanManager.Find(x => x.ID == id.Value);
            if (calisan == null)
            {
                return HttpNotFound();
            }
            return View(calisan);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calisan calisan = yardimciCalisanManager.Find(x => x.ID == id);
            yardimciCalisanManager.Delete(calisan);
            yardimciCalisanManager.Save();
            return RedirectToAction("Index");
        }

        
    }
}
