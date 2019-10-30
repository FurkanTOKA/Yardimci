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
    [Table("Yardımcılar")]
    public class Calisan : EntityBase
    {
        [Required, StringLength(50)]
        public String Ad { get; set; }

        [Required, StringLength(50)]
        public String SoyAd { get; set; }

        [Required, StringLength(50)]
        public String Tip { get; set; }

        [Required, StringLength(50)]
        public String TelefonNo { get; set; }

        [Required, StringLength(50)]
        public String KullaniciAdi { get; set; }

        [Required, StringLength(255)]
        public String Email { get; set; }

        [Required, StringLength(100)]
        public String Sifre { get; set; }

        [StringLength(150)] //images/user_15.jpg
        public String ProfileImageFileName { get; set; }

        [Required]
        public int SaatlikUcret { get; set; }

        
        public int YaptigiIs { get; set; }



        [ScaffoldColumn(false), DisplayName("Kullanıcı aktif mi")]
        public bool AktifMi { get; set; }

        [ScaffoldColumn(false), DisplayName("Kullanıcı admin mi")]
        public bool AdminMi { get; set; }

        [ScaffoldColumn(false), DisplayName("Kullanıcı yardımcı mı")]
        public bool YardimciMi { get; set; }


        
        public Guid AktivasyonGuid { get; set; }
        
        



        public virtual List<Yorumlar> Yorumlar { get; set; }
        public virtual Hizmetler hizmetler { get; set; }
        public virtual List<Liked> Liked { get; set; }

        public virtual Siparis siparis { get; set; }
        

        public Calisan()
        {
            Yorumlar = new List<Yorumlar>();
            Liked = new List<Liked>();
        }







    }
}
