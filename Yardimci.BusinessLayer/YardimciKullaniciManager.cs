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
    public class YardimciKullaniciManager : ManagerBase<Kullanici>
    {
        //Buraya bak.
        
        


        public BusinessLayerResult<Kullanici> RegisterUser(RegisterViewModel data)
        {
           Kullanici user = Find(x => x.KullaniciAdi == data.KullaniciAdi || x.Email == data.Email || x.TelefonNo == data.TelefonNo);
            BusinessLayerResult<Kullanici> res = new BusinessLayerResult<Kullanici>();

            BusinessLayerResult<Calisan> cal = new BusinessLayerResult<Calisan>();
           
            


            if (user != null)
            {
                if(user.KullaniciAdi == data.KullaniciAdi)
                {
                    res.AddError(ErrorMessageCode.UserNameAlreadyExists, "Kullanıcı adı kayıtlı");
                }
                if(user.Email == data.Email)
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
                int dbResult = base.Insert(new Kullanici()
                {
                    KullaniciAdi = data.KullaniciAdi,
                    Email = data.Email,
                    Sifre = data.Sifre,
                    Ad = data.Ad,
                    SoyAd = data.SoyAd,
                    TelefonNo = data.TelefonNo,
                    ProfileImageFileName = "user-avatar.png",
                    AdminMi = false,
                    AktifMi = false,
                    YardimciMi = false,
                    AktivasyonGuid = Guid.NewGuid()



                });
                if(dbResult > 0)
                {
                    res.Result =  Find(x => x.Email == data.Email && x.KullaniciAdi == data.KullaniciAdi);

                    //Aktivasyon maili atılacaktır.
                    //layerResult.Result.AktivasyonGuid

                    string siteUri = ConfigHelper.Get<string>("SiteRootUri");
                    string activeUri = $"{siteUri}/Home/KullaniciAktif/{res.Result.AktivasyonGuid}";
                    string body = $"Merhaba {res.Result.Ad} {res.Result.SoyAd}; Hesabınızı aktifleştirmek için <a href='{activeUri}' target='_blank'>tıklayınız</a>.";

                    MailHelper.SendMail(body, res.Result.Email,"Yardimci.NET Hesap aktifleştirme");

                }
            }


            return res;
        }

        public BusinessLayerResult<Kullanici> GetUserById(int id)
        {
            BusinessLayerResult<Kullanici> res = new BusinessLayerResult<Kullanici>();
            res.Result = Find(x => x.ID == id);

            if( res.Result == null)
            {
                res.AddError(ErrorMessageCode.UserNotFound, "Kullanici bulunamadı");
            }

            return res;
        }

        public BusinessLayerResult<Kullanici> LoginUser(LoginViewModel data)
        {
            BusinessLayerResult<Kullanici> res = new BusinessLayerResult<Kullanici>();
            res.Result = Find(x => x.KullaniciAdi == data.Username && x.Sifre == data.Password);

         


            if (res.Result != null)
            {
                if(!res.Result.AktifMi)
                {
                    res.AddError(ErrorMessageCode.UserIsNoteActive, "Aktifleşmemiş hesap. Lütfen mail adresinizi kontrol ediniz.");
                }
                
            }
            else
            {
                res.AddError(ErrorMessageCode.UserNameOrPassWrong, "Kullanıcı adı veya şifre hatalıdır");
            }

            return res;
        }

        public BusinessLayerResult<Kullanici> ActivateUser(Guid activateId)
        {
            BusinessLayerResult<Kullanici> res = new BusinessLayerResult<Kullanici>();
            res.Result = Find(x => x.AktivasyonGuid == activateId);

            if(res.Result != null)
            {
                if(res.Result.AktifMi)
                {
                    res.AddError(ErrorMessageCode.UserAlreadyActive,"Kullanıcı zaten aktiftir.");

                    return res;
                }
                res.Result.AktifMi = true;
                Update(res.Result);
            }
            else
            {
                res.AddError(ErrorMessageCode.AktivateIdDoesNotExists, "Aktifleştirelecek kullanıcı bulunamadı.");

            }
            return res;

        }

        public BusinessLayerResult<Kullanici> UpdateProfile(Kullanici data)
        {
            Kullanici db_user = Find(x => x.ID != data.ID && (x.KullaniciAdi == data.KullaniciAdi || x.Email == data.Email));
            BusinessLayerResult<Kullanici> res = new BusinessLayerResult<Kullanici>();
            
            if(db_user != null && db_user.ID != data.ID)
            {
                if(db_user.KullaniciAdi == data.KullaniciAdi)
                {
                    res.AddError(ErrorMessageCode.UserNameAlreadyExists, "Kullanıcı adı kayıtlı.");
                }
                if(db_user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "Eposta adresi kayıtlı.");
                }
                if (db_user.TelefonNo == data.TelefonNo)
                {
                    res.AddError(ErrorMessageCode.PhoneNumberExists ,"Telefon no  kayıtlı.");
                }

                return res;
            }
            res.Result = Find(x => x.ID == data.ID);
            //res.Result.Email = data.Email;
            res.Result.Ad = data.Ad;
            res.Result.SoyAd = data.SoyAd;
            res.Result.Sifre = data.Sifre;
            //res.Result.TelefonNo = data.TelefonNo;

            if(string.IsNullOrEmpty(data.ProfileImageFileName)==false)
            {
                res.Result.ProfileImageFileName = data.ProfileImageFileName;
            }
            if(base.Update(res.Result)==0)
            {
                res.AddError(ErrorMessageCode.ProfileCoulNotUpdated, "Profil Güncellenemedi.");
            }

            return res;

        }

        public BusinessLayerResult<Kullanici> RemoveUserById(int id)
        {
            BusinessLayerResult<Kullanici> res = new BusinessLayerResult<Kullanici>();
            Kullanici user = Find(x => x.ID == id);

            if(user != null)
            {
                if(Delete(user) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldNotRemove, "Kullanıcı silinemedi.");

                    return res;
                }
                
            }
            else
            {
                res.AddError(ErrorMessageCode.UserCouldNotFind, "Kullanıcı bulunamadı.");
            }
            return res;

        }

        //Geri dönüş tipini değiştirebileceğimiz oveerrida diyebiliriz.
        //Method gizleme
        public new BusinessLayerResult<Kullanici> Insert(Kullanici data)
        {
            Kullanici user = Find(x => x.KullaniciAdi == data.KullaniciAdi || x.Email == data.Email || x.TelefonNo == data.TelefonNo);
            BusinessLayerResult<Kullanici> res = new BusinessLayerResult<Kullanici>();

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

               
               
                if(base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldInserted, "Kullanıcı eklenemedi.");
                }
            }


            return res;
        }



        public new BusinessLayerResult<Kullanici> Update(Kullanici data)
        {
            

            Kullanici db_user = Find(x => x.ID != data.ID && (x.KullaniciAdi == data.KullaniciAdi || x.Email == data.Email));
            BusinessLayerResult<Kullanici> res = new BusinessLayerResult<Kullanici>();

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
            res.Result.Email = data.Email;
            res.Result.Ad = data.Ad;
            res.Result.SoyAd = data.SoyAd;
            res.Result.Sifre = data.Sifre;

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
