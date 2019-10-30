using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yardimci.Entities.ValueObjects
{
    public class RegisterViewModel
    {
        [DisplayName("Adınız"), 
            Required(ErrorMessage = "{0} alanı boş geçilemez."), 
            StringLength(25, ErrorMessage = "{0} max. {1} karater olmalıdır.")]
        public String Ad { get; set; }

        [DisplayName("Soyadınız"), 
            Required(ErrorMessage = "{0} alanı boş geçilemez."), 
            StringLength(25, ErrorMessage = "{0} max. {1} karater olmalıdır.")]
        public String SoyAd { get; set; }


        [DisplayName("Kullanıcı Adınız"), 
            Required(ErrorMessage = "{0} alanı boş geçilemez."), 
            StringLength(25, ErrorMessage = "{0} max. {1} karater olmalıdır.")]
        public String KullaniciAdi { get; set; }

        

        [DisplayName("Şifreniz"), 
            Required(ErrorMessage = "{0} alanı boş geçilemez."), 
            DataType(DataType.Password), 
            StringLength(25, ErrorMessage = "{0} max. {1} karater olmalıdır.")]
        public String Sifre { get; set; }

        [DisplayName("Şifre Tekrar"), 
            Required(ErrorMessage = "{0} alanı boş geçilemez."), 
            DataType(DataType.Password), 
            StringLength(70, ErrorMessage = "{0} max. {1} karater olmalıdır."),
            Compare("Sifre", ErrorMessage = "{0} ile {1} uyuşmamaktadır.")]
        public String ReSifre { get; set; }


        [DisplayName("Telefon Numaranız"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(25, ErrorMessage = "{0} max. {1} karater olmalıdır.")]
        public String TelefonNo { get; set; }

        


        [DisplayName("Eposta Adresiniz"), 
            Required(ErrorMessage = "{0} alanı boş geçilemez."), 
            StringLength(70, ErrorMessage = "{0} max. {1} karater olmalıdır."), 
            EmailAddress(ErrorMessage ="{0} alanı için geçerli bir e-posta giriniz.")]
        public String Email { get; set; }

        [DisplayName("Eposta Tekrar"), 
            Required(ErrorMessage = "{0} alanı boş geçilemez."), 
            StringLength(70, ErrorMessage = "{0} max. {1} karater olmalıdır."), 
            Compare("Email", ErrorMessage ="{0} ile {1} uyuşmamaktadır.")]
        public String ReEmail { get; set; }

        
    }
}