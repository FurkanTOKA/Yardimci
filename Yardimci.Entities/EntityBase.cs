using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yardimci.Entities
{
    public class EntityBase
    {
        //Otomatik artan ve Primary Key
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        //Boş geçilemez.
        [Required]
        public DateTime OlusturulmaZamani { get; set; }

        [Required]
        public DateTime DegistirilmeZamani { get; set; }

        [Required,StringLength(30)]
        public string DegistirenKullanici { get; set; }
    }
}
