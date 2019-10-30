using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yardimci.DataAccsessLayer.EntityFrameWork;
using Yardimci.Entities;
using Yardimci.BusinessLayer.Results;
using Yardimci.BusinessLayer.Abstract;


namespace Yardimci.BusinessLayer
{
    public class Test
    {
        private Repository<Kullanici> repo = new Repository<Kullanici>();
        
        //private Repository<Yorumlar> repo_yorum = new Repository<Yorumlar>();
        //private Repository<Calisan> repo_calisan = new Repository<Calisan>();
       // private Repository<Hizmetler> repo_hizmet = new Repository<Hizmetler>();

        public Test()
        {

            List<Kullanici> user = repo.List();
            
        }


        public Repository<Calisan> InsertCalisanTest()
        {
            Repository<Calisan> repo_calisan = new Repository<Calisan>();


            int result = repo_calisan.Insert(new Calisan()
            {
                Ad = "Özgür",
                SoyAd = "Ozbek",
                TelefonNo = "531 974 5555",
                SaatlikUcret=40,
                YaptigiIs =5,
                Email = "furkantokatrtr@hotmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = true,
                KullaniciAdi = "ozgurozbek",
                Sifre = "12345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "TOKAFURKAN",
                Tip="Temizlik"
       
            

            });
            int result3 = repo_calisan.Insert(new Calisan()
            {
                Ad = "Ertuğrul",
                SoyAd = "Aydın",
                TelefonNo = "530 224 5555",
                SaatlikUcret = 35,
                YaptigiIs = 12,
                Email = "abc@hotmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = true,
                KullaniciAdi = "ertugrul",
                Sifre = "12345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "TOKAFURKAN",
                Tip = "Boya - Badana"



            });

            int result2 = repo_calisan.Insert(new Calisan()
            {
                Ad = "Fırat",
                SoyAd = "Ozbek",
                TelefonNo = "531 033 5555",
                Email = "rtr@hotmail.com",
                SaatlikUcret =50,
                YaptigiIs = 12,
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = true,
                KullaniciAdi = "fırat",
                Sifre = "122345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "TOKAFURKAN",
                Tip="Hasta Bakımı"
               
            });

            return repo_calisan;
        }

        public void InsertHizmetTest()
        {
            Repository<Hizmetler> repo_hizmet = new Repository<Hizmetler>();
            Repository<Calisan> c = new Repository<Calisan>();

            //int id=repo_hizmet.List().Where(a => a.Baslik == "Temizlik").Select(a=>a.ID).FirstOrDefault();
            //List<Calisan> cal = c.List().Where(a => a.hizmetler.ID == id).ToList();

            int result = repo_hizmet.Insert(new Hizmetler()
            {
                Baslik = "Temizlik",
                HizmetTuru = "Ev ve iş yerleriniz profesyonel çalışanlarımız tarafından temizlenir.",
                OlusturulmaZamani = DateTime.Now,
                DegistirenKullanici = "TOKAFURKAN",
                DegistirilmeZamani = DateTime.Now,
                calisan = InsertCalisanTest().List().Where(a=>a.Tip=="Temizlik").ToList()
                
                
            });

            int result2 = repo_hizmet.Insert(new Hizmetler()
            {
                Baslik = "Hasta Bakımı",
                HizmetTuru = "Hasta Bakımı",
                OlusturulmaZamani = DateTime.Now,
                DegistirenKullanici = "TOKAFURKAN",
                DegistirilmeZamani = DateTime.Now,
                calisan = InsertCalisanTest().List().Where(a => a.Tip == "Hasta Bakımı").ToList()
            });

            int result3 = repo_hizmet.Insert(new Hizmetler()
            {
                Baslik = "Boya - Badana",
                HizmetTuru = "Boya - Badana",
                OlusturulmaZamani = DateTime.Now,
                DegistirenKullanici = "TOKAFURKAN",
                DegistirilmeZamani = DateTime.Now,
                calisan = InsertCalisanTest().List().Where(a => a.Tip == "Boya - Badana").ToList()



            });
        }


    }
}










