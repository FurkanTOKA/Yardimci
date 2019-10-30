using Deneme2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yardimci.Entities;

namespace Yardimci.WebApp.Init
{
    public class Deneme2Common : IDeneme2
    {
        public string GetCurrentUsername()
        {
            if(HttpContext.Current.Session["login"] != null)
            {
                Kullanici user = HttpContext.Current.Session["login"] as Kullanici;

                return user.KullaniciAdi;
            }

            
            return "system";
            
        }
    }
}