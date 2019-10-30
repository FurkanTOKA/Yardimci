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


namespace Yardimci.WebApp.Controllers
{
    public class KullaniciController : Controller
    {

        private YardimciKullaniciManager yardimciKullaniciManager = new YardimciKullaniciManager();

         

        
        public ActionResult Index()
        {
            return View(yardimciKullaniciManager.List());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = yardimciKullaniciManager.Find(x => x.ID == id.Value);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        
        public ActionResult Create()
        {
            return View();
        }

       

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kullanici kullanici)
        {
            ModelState.Remove("OlusturulmaZamani");
            ModelState.Remove("DegistirilmeZamani ");
            ModelState.Remove("DegistirenKullanici");
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Kullanici> res = yardimciKullaniciManager.Insert(kullanici);

                if(res.Errors.Count >  0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    return View(kullanici);
                }

                return RedirectToAction("Index");
            }

            return View(kullanici);
        }

        
        public ActionResult Edit(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = yardimciKullaniciManager.Find(x => x.ID == id.Value);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kullanici kullanici)
        {
            ModelState.Remove("OlusturulmaZamani");
            ModelState.Remove("DegistirilmeZamani ");
            ModelState.Remove("DegistirenKullanici");
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Kullanici> res = yardimciKullaniciManager.Update(kullanici);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    return View(kullanici);
                }
                return RedirectToAction("Index");
            }
            return View(kullanici);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = yardimciKullaniciManager.Find(x => x.ID == id.Value);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanici kullanici = yardimciKullaniciManager.Find(x => x.ID == id);

            yardimciKullaniciManager.Delete(kullanici);

            return RedirectToAction("Index");
        }

       
    }
}
