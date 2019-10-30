using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yardimci.Entities 
{
    [Table("Siparisler")]
    public class Siparis : EntityBase
    {
        [Required, StringLength(200)]
        public String SiparisAdres { get; set; }

        [Required, StringLength(15)]
        public String TelefonNo { get; set; }

        public virtual List<Kullanici> kullanici { get; set; }
        public virtual List<Calisan>  calisan { get; set; }




    }
}
