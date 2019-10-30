using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Yardimci.BusinessLayer;
using Yardimci.Entities;


namespace Yardimci.WebApp.Controllers
{
    public class HizmetlerController : Controller
    {
        private HizmetlerManager hizmetlerManager = new HizmetlerManager();

        

        
        public ActionResult Index()
        {
            return View(hizmetlerManager.List());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hizmetler hizmetler = hizmetlerManager.Find(x => x.ID == id.Value);
            if (hizmetler == null)
            {
                return HttpNotFound();
            }
            return View(hizmetler);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hizmetler hizmetler)
        {
            ModelState.Remove("OlusturulmaZamani");
            ModelState.Remove("DegistirilmeZamani ");
            ModelState.Remove("DegistirenKullanici");

            if (ModelState.IsValid)
            {
                hizmetlerManager.Insert(hizmetler);
                return RedirectToAction("Index");
            }

            return View(hizmetler);
        }

        
        public ActionResult Edit(int? id)
        {

            ModelState.Remove("OlusturulmaZamani");
            ModelState.Remove("DegistirilmeZamani ");
            ModelState.Remove("DegistirenKullanici");


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hizmetler hizmetler = hizmetlerManager.Find(x => x.ID == id.Value);
            if (hizmetler == null)
            {
                return HttpNotFound();
            }
            return View(hizmetler);
        }

        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hizmetler hizmetler)
        {
            ModelState.Remove("OlusturulmaZamani");
            ModelState.Remove("DegistirilmeZamani ");
            ModelState.Remove("DegistirenKullanici");
            if (ModelState.IsValid)
            {
                Hizmetler hiz = hizmetlerManager.Find(x => x.ID == hizmetler.ID);
                hiz.Baslik = hizmetler.Baslik;
                hiz.HizmetTuru = hizmetler.HizmetTuru;

                hizmetlerManager.Update(hiz);
            }
            return View(hizmetler);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hizmetler hizmetler = hizmetlerManager.Find(x => x.ID == id.Value);
            if (hizmetler == null)
            {
                return HttpNotFound();
            }
            return View(hizmetler);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hizmetler hizmetler = hizmetlerManager.Find(x => x.ID == id);
            hizmetlerManager.Delete(hizmetler);


            return RedirectToAction("Index");
        }

        
    }
}
