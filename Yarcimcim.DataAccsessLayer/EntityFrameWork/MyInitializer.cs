using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Yardimci.Entities;


namespace Yardimci.DataAccsessLayer.EntityFrameWork
{
    class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Kullanici admin = new Kullanici()
            {
                Ad = "Furkan",
                SoyAd = "Toka",
                TelefonNo="531 974 0333",
                Email = "furkantokatr@gmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = true,
                YardimciMi = false,
                KullaniciAdi = "furkantoka",
                ProfileImageFileName = "user-avatar.png",
                Sifre = "123456",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = null
            };

            Kullanici kullanici = new Kullanici()
            {
                Ad = "Özgür",
                SoyAd = "Bulut",
                TelefonNo="0800 800 0808",
                Email = "asd@gmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = false,
                KullaniciAdi = "ozgurbulut",
                ProfileImageFileName = "user-avatar.png",
                Sifre = "12345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "furkantoka"
            };
            Kullanici kullanici2 = new Kullanici()
            {
                Ad = "Fırat",
                SoyAd = "Özbek",
                TelefonNo = "0531 974 0333",
                Email = "xyz@gmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = false,
                KullaniciAdi = "fıratozbek",
                ProfileImageFileName = "user-avatar.png",
                Sifre = "12345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "furkantoka"
            };
            Kullanici kullanici3 = new Kullanici()
            {
                Ad = "Ertuğrul",
                SoyAd = "Aydın",
                TelefonNo = "0533 436 2968",
                Email = "xyz123@gmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = false,
                KullaniciAdi = "ertugrulaydin",
                ProfileImageFileName = "user-avatar.png",
                Sifre = "12345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "furkantoka"
            };

            Calisan calisan1 = new Calisan()
            {
                Ad = "Burak",
                SoyAd = "Teke",
                TelefonNo = "531 974 5555",
                SaatlikUcret = 40,
                YaptigiIs = 5,
                Email = "burakteke@hotmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = true,
                KullaniciAdi = "burakteke",
                ProfileImageFileName = "user-avatar.png",
                Sifre = "12345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "furkantoka",
                Tip = "Temizlik"
            };
            Calisan calisan2 = new Calisan()
            {
                Ad = "Ertugrul",
                SoyAd = "Aydınn",
                TelefonNo = "123 123 1233",
                SaatlikUcret = 100,
                YaptigiIs =30,
                Email = "1234566@hotmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = true,
                KullaniciAdi = "e2tugrul",
                ProfileImageFileName = "user-avatar.png",
                Sifre = "12345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "furkantoka",
                Tip = "Boya - Badana"
            };
            Calisan calisan3 = new Calisan()
            {
                Ad = "Ali",
                SoyAd = "Gunes",
                TelefonNo = "987 987 9877",
                SaatlikUcret = 200,
                YaptigiIs = 40,
                Email = "aligunes@hotmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = true,
                KullaniciAdi = "aligunes",
                ProfileImageFileName = "user-avatar.png",
                Sifre = "12345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "furkantoka",
                Tip = "Hasta Bakımı"
            };
            Calisan calisan4 = new Calisan()
            {
                Ad = "Engin",
                SoyAd = "Canik",
                TelefonNo = "531 531 5333",
                SaatlikUcret = 40,
                YaptigiIs = 15,
                Email = "engincanik@hotmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = true,
                KullaniciAdi = "engincanik",
                ProfileImageFileName = "user-avatar.png",
                Sifre = "12345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "furkantoka",
                Tip = "Hasta Bakımı"
            };
            Calisan calisan5 = new Calisan()
            {
                Ad = "Pınar",
                SoyAd = "Cin",
                TelefonNo = "544 123 4321",
                SaatlikUcret = 60,
                YaptigiIs = 22,
                Email = "pınarcin@hotmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = true,
                KullaniciAdi = "pınarcin",
                ProfileImageFileName = "user-avatar.png",
                Sifre = "12345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "furkantoka",
                Tip = "Temizlik"
            };
            Calisan calisan6 = new Calisan()
            {
                Ad = "Enis",
                SoyAd = "Çapkın",
                TelefonNo = "544 123 3131",
                SaatlikUcret = 70,
                YaptigiIs = 8,
                Email = "eniscapkin@hotmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = true,
                KullaniciAdi = "eniscapkin",
                ProfileImageFileName = "user-avatar.png",
                Sifre = "12345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "furkantoka",
                Tip = "Temizlik"
            };
            Calisan calisan7 = new Calisan()
            {
                Ad = "Ahmet",
                SoyAd = "Bulut",
                TelefonNo = "544 643 4321",
                SaatlikUcret = 300,
                YaptigiIs = 1,
                Email = "ahmetbulut@hotmail.com",
                AktivasyonGuid = Guid.NewGuid(),
                AktifMi = true,
                AdminMi = false,
                YardimciMi = true,
                KullaniciAdi = "ahmetbulut",
                ProfileImageFileName = "user-avatar.png",
                Sifre = "12345",
                OlusturulmaZamani = DateTime.Now,
                DegistirilmeZamani = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "furkantoka",
                Tip = "Temizlik"
            };

            Liked like = new Liked()
            {
                LikedCalisan = calisan1,
                LikedKullanici = kullanici2
                
            };
            Liked like1 = new Liked()
            {
                LikedCalisan = calisan2,
                LikedKullanici = kullanici2
        };
            Liked like2 = new Liked()
            {
                LikedCalisan = calisan2,
                LikedKullanici = kullanici2
    };
            Liked like3 = new Liked()
            {
                LikedCalisan = calisan2,
                LikedKullanici = kullanici2
        };
            Liked like4 = new Liked()
            {
                LikedCalisan = calisan5,
                LikedKullanici = kullanici
    };
            Liked like5 = new Liked()
            {
                LikedCalisan = calisan6,
                LikedKullanici = kullanici2
        };
            Liked like6 = new Liked()
            {
                LikedKullanici = kullanici2,
                LikedCalisan = calisan7
            };

            //context.Kullanicilar.Add(admin);

            context.Kullanicilar.Add(kullanici);
            context.Kullanicilar.Add(kullanici2);
            context.Kullanicilar.Add(kullanici3);
            

            context.Calisanlar.Add(calisan1);
            context.Calisanlar.Add(calisan2);
            context.Calisanlar.Add(calisan3);
            context.Calisanlar.Add(calisan4);
            context.Calisanlar.Add(calisan5);
            context.Calisanlar.Add(calisan6);
            context.Calisanlar.Add(calisan7);
            
            


            context.SaveChanges();

            context.Likes.Add(like);
            context.Likes.Add(like1);
            context.Likes.Add(like2);
            context.Likes.Add(like3);
            context.Likes.Add(like4);
            context.Likes.Add(like5);
            context.Likes.Add(like6);
            context.SaveChanges();
            Hizmetler hizmet2 = new Hizmetler()
            {
                Baslik = "Boya - Badana",
                HizmetTuru = "Ev ve iş yerleriniz profesyonel çalışanlarımız tarafından boyanır.",
                OlusturulmaZamani = DateTime.Now,
                DegistirenKullanici = "furkantoka",
                DegistirilmeZamani = DateTime.Now,
                calisan = context.Calisanlar.Where(a => a.Tip == "Boya - Badana").ToList()
            };
            Hizmetler hizmet3 = new Hizmetler()
            {
                Baslik = "Temizlik",
                HizmetTuru = "Ev ve iş yerleriniz profesyonel çalışanlarımız tarafından temizlenir.",
                OlusturulmaZamani = DateTime.Now,
                DegistirenKullanici = "furkantoka",
                DegistirilmeZamani = DateTime.Now,
                calisan = context.Calisanlar.Where(a => a.Tip == "Temizlik").ToList()
            };
            Hizmetler hizmet4 = new Hizmetler()
            {
                Baslik = "Hasta Bakımı",
                HizmetTuru = "Hastalarınızla biz ilgileniriz.",
                OlusturulmaZamani = DateTime.Now,
                DegistirenKullanici = "furkantoka",
                DegistirilmeZamani = DateTime.Now,
                calisan = context.Calisanlar.Where(a => a.Tip == "Hasta Bakımı").ToList()
            };
            
            context.Hizmetler.Add(hizmet2);
            context.Hizmetler.Add(hizmet3);
            context.Hizmetler.Add(hizmet4);
            context.SaveChanges();


        }
    }
}
