using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yardimci.Entities;

namespace Yardimci.DataAccsessLayer.EntityFrameWork
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Hizmetler> Hizmetler { get; set; }
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Yorumlar> Yorumlar { get; set; }
        public DbSet<Liked> Likes { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }

    } 

    
}
