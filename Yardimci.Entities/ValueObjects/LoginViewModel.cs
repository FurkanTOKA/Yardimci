using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yardimci.Entities.ValueObjects
{
    public class LoginViewModel
    {
        [DisplayName("Adınız"), Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(25, ErrorMessage = "{0} max. {1} karater olmalıdır.")]
        public string Username { get; set; }


        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez."),DataType(DataType.Password), StringLength(25, ErrorMessage = "{0} max. {1} karater olmalıdır.")]
        public string Password { get; set; }
    }
}