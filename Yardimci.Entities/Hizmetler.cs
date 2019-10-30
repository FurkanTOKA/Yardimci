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
    [Table("Hizmetler")]
    public class Hizmetler : EntityBase

    {
        [DisplayName("Hizmet Adı"),Required, StringLength(50)]
        public string Baslik { get; set; }

        [DisplayName("Hizmet Açıklaması"), StringLength(150)]
        public String HizmetTuru { get; set; }

        public virtual List<Calisan> calisan { get; set; } 

        public Hizmetler()
        {
            calisan = new List<Calisan>();
        }




    }
}
