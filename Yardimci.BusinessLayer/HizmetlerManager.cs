using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarcimcim.Core.DataAccess;
using Yardimci.BusinessLayer.Abstract;
using Yardimci.DataAccsessLayer.EntityFrameWork;
using Yardimci.Entities;

namespace Yardimci.BusinessLayer
{
    public class HizmetlerManager : ManagerBase<Hizmetler>
    {
        //Bölüm 30 ders 195
        /*public override int Delete(Hizmetler hizmetler)
        {
            CalisanlarManager calisanlarManager = new CalisanlarManager();

            //Hizmetler ile ilişkili çalışanları silmek gerekir.
            foreach (Calisan cal in hizmetler.calisan.ToList())
            {
                calisanlarManager.Delete(ca);
            }

            return base.Delete(hizmetler);
        }*/

    }
}
