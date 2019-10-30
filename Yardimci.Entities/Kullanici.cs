using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yardimci.Entities
{
    [Table("Kullanıcılar")]
    public class Kullanici :EntityBase
    {
        [DisplayName("Ad"), Required, StringLength(50)]
        public String Ad { get; set; }

        [DisplayName("Soy Ad"), Required, StringLength(50)]
        public String SoyAd { get; set; }

        [DisplayName("Telefon Numarası"), Required, StringLength(50)]
        public String TelefonNo { get; set; }

        
        [DisplayName("Kullanıcı Adı"), Required, StringLength(50)]
        public String KullaniciAdi { get; set; }

        [DisplayName("Eposta Adresi"), Required, StringLength(70)]
        public String Email { get; set; }

        [DisplayName("Şifre"), Required, StringLength(100)]
        public String Sifre { get; set; }

        [StringLength(150),ScaffoldColumn(false)] //images/user_15.jpg
        public String ProfileImageFileName { get; set; }

        [ScaffoldColumn(false),DisplayName("Kullanıcı aktif mi")]
        public bool AktifMi { get; set; }

        [ScaffoldColumn(false),DisplayName("Kullanıcı admin mi")]
        public bool AdminMi { get; set; }

        [ScaffoldColumn(false),DisplayName("Kullanıcı yardımcı mı")]
        public bool YardimciMi { get; set; }

        [Required,ScaffoldColumn(false)]
        public Guid AktivasyonGuid { get; set; }

        public virtual List<Yorumlar> Yorumlar { get; set; }
        public virtual List<Liked> Likes { get; set; }

        public virtual List<Siparis> siparis { get; set; }

        public Kullanici()
        {
            siparis = new List<Siparis>();
            Yorumlar = new List<Yorumlar>();

        }

    }
}
