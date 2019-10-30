using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Yardimci.DataAccsessLayer;
using Yardimci.Entities;
using System.Data.Entity;

namespace Yardimci.DataAccsessLayer.EntityFrameWork
{
    public class RepositoryBase
    {
        protected static DatabaseContext context;
        private static object _lockSync = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if(context == null )
            {
                lock (_lockSync)
                {
                    if(context ==null)
                    {
                        context = new DatabaseContext();
                    }
                    
                }
                
            }

        }
    }
}
