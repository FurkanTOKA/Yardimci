using Deneme2.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yardimci.DataAccsessLayer.EntityFrameWork;
using Yardimci.Entities;
using Yardimci.Entities.Messages;
using Yardimci.Entities.ValueObjects;
using System.Net;
using Yardimci.BusinessLayer.Results;
using Yardimci.BusinessLayer.Abstract;


namespace Yardimci.BusinessLayer
{
    public class YardimciCalisanManager : ManagerBase<Calisan>
    {

        public BusinessLayerResult<Calisan> RegisterCalisan(CalisanRegisterViewModel data)
        {
            Calisan user = Find(x => x.KullaniciAdi == data.KullaniciAdi || x.Email == data.Email || x.TelefonNo == data.TelefonNo);
            
            BusinessLayerResult<Calisan> res = new BusinessLayerResult<Calisan>();

            if (user != null)
            {
                if (user.KullaniciAdi == data.KullaniciAdi)
                {
                    res.AddError(ErrorMessageCode.UserNameAlreadyExists, "Kullanıcı adı kayıtlı");
                }
                if (user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "EPosta adresi kayıtlı");
                }
                if (user.TelefonNo == data.TelefonNo)
                {
                    res.AddError(ErrorMessageCode.PhoneNumberExists, "Telefon numarası  kayıtlı");
                }
            }
            else
            {
                int dbResult = base.Insert(new Calisan()
                {
                    KullaniciAdi = data.KullaniciAdi,
                    Email = data.Email,
                    Sifre = data.Sifre,
                    Ad = data.Ad,
                    SoyAd = data.SoyAd,
                    TelefonNo = data.TelefonNo,
                    Tip = data.Tip,
                    SaatlikUcret =data.SaatlikUcret,
                    ProfileImageFileName = "user-avatar.png",
                    AdminMi = false,
                    AktifMi = false,
                    YardimciMi = true,
                    AktivasyonGuid = Guid.NewGuid()
                });
                if (dbResult > 0)
                {
                    res.Result = Find(x => x.Email == data.Email && x.KullaniciAdi == data.KullaniciAdi);

                    //Aktivasyon maili atılacaktır.
                    //layerResult.Result.AktivasyonGuid

                    string siteUri = ConfigHelper.Get<string>("SiteRootUri");
                    string activeUri = $"{siteUri}/Home/KullaniciAktif/{res.Result.AktivasyonGuid}";
                    string body = $"Merhaba {res.Result.Ad} {res.Result.SoyAd}; Hesabınızı aktifleştirmek için <a href='{activeUri}' target='_blank'>tıklayınız</a>.";

                    MailHelper.SendMail(body, res.Result.Email, "Yardimci.NET Hesap aktifleştirme");

                }
            }


            return res;
        }


        public new BusinessLayerResult<Calisan> Insert(Calisan data)
        {
            Calisan user = Find(x => x.KullaniciAdi == data.KullaniciAdi || x.Email == data.Email || x.TelefonNo == data.TelefonNo);
            BusinessLayerResult<Calisan> res = new BusinessLayerResult<Calisan>();

            res.Result = data;

            if (user != null)
            {
                if (user.KullaniciAdi == data.KullaniciAdi)
                {
                    res.AddError(ErrorMessageCode.UserNameAlreadyExists, "Kullanıcı adı kayıtlı");
                }
                if (user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "EPosta adresi kayıtlı");
                }
                if (user.TelefonNo == data.TelefonNo)
                {
                    res.AddError(ErrorMessageCode.PhoneNumberExists, "Telefon numarası  kayıtlı");
                }
            }
            else
            {
                res.Result.ProfileImageFileName = "user-avatar.png";
                res.Result.AktivasyonGuid = Guid.NewGuid();



                if (base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldInserted, "Kullanıcı eklenemedi.");
                }
            }


            return res;
        }


        public new BusinessLayerResult<Calisan> Update(Calisan data)
        {


            Calisan db_user = Find(x => x.ID != data.ID && (x.KullaniciAdi == data.KullaniciAdi || x.Email == data.Email));
            BusinessLayerResult<Calisan> res = new BusinessLayerResult<Calisan>();

            res.Result = data;

            if (db_user != null && db_user.ID != data.ID)
            {
                if (db_user.KullaniciAdi == data.KullaniciAdi)
                {
                    res.AddError(ErrorMessageCode.UserNameAlreadyExists, "Kullanıcı adı kayıtlı.");
                }
                if (db_user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "Eposta adresi kayıtlı.");
                }
                if (db_user.TelefonNo == data.TelefonNo)
                {
                    res.AddError(ErrorMessageCode.PhoneNumberExists, "Telefon no  kayıtlı.");
                }

                return res;
            }
            res.Result = Find(x => x.ID == data.ID);

            res.Result.Ad = data.Ad;
            res.Result.SoyAd = data.SoyAd;
            res.Result.Tip = data.Tip;
            res.Result.TelefonNo = data.TelefonNo;
            res.Result.KullaniciAdi = data.KullaniciAdi;
            res.Result.Email = data.Email;
            res.Result.Sifre = data.Sifre;
            res.Result.SaatlikUcret = data.SaatlikUcret;
            res.Result.YaptigiIs = 0;







            res.Result.AktifMi = data.AktifMi;
            res.Result.AdminMi = data.AdminMi;
            res.Result.YardimciMi = data.YardimciMi;


            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.UserCouldNotUpdated, "Profil Güncellenemedi.");
            }

            return res;
        }
    }
}
