using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yardimci.Entities
{
    [Table("Yorumlar")]
    public class Yorumlar :EntityBase
    {
        [Required, StringLength(300)]
        public string Yorum { get; set; }

        public virtual Calisan Yardimci { set; get; }
        public virtual Kullanici Kullanici { get; set; }
        public Calisan Calisan { get; set; }
    }
}
