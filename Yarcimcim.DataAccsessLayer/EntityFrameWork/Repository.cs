using Deneme2.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Yarcimcim.Core.DataAccess;

using Yardimci.Entities;


namespace Yardimci.DataAccsessLayer.EntityFrameWork
{
    public class Repository<T>: RepositoryBase, IDataAccess<T> where T : class
    {
       
        private DbSet<T> _objectSet;

        public Repository()
        {
            
            _objectSet = context.Set<T>();
        }
        public List<T> List()
        {
            return _objectSet.ToList();
        }
        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }

        public List<T> List(Expression<Func<T,bool>> where  )
        {
            return _objectSet.Where(where).ToList();
        }

        public int Insert(T obj)
        {
            

            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;
                DateTime now = DateTime.Now;

                o.OlusturulmaZamani = now;
                o.DegistirilmeZamani = now;
                o.DegistirenKullanici = AppDeneme2.deneme.GetCurrentUsername(); //İşlem yapan kullanıcı adı yazılmalı

            }
            _objectSet.Add(obj);
            return Save();
        }

        public int Update(T obj)
        {
            
            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;
                DateTime now = DateTime.Now;

                
                o.DegistirilmeZamani = now;
                o.DegistirenKullanici = AppDeneme2.deneme.GetCurrentUsername();//Yard.Common.GetUsername(); //İşlem yapan kullanıcı adı yazılmalı

            }
            //---------DENEMEEEEE-----------
            //_objectSet.Add(obj);

            return context.SaveChanges();
        }

        public int Delete(T obj)
        {
            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;
                DateTime now = DateTime.Now;


                o.DegistirilmeZamani = now;
                o.DegistirenKullanici = "System"; //İşlem yapan kullanıcı adı yazılmalı

            }
            _objectSet.Remove(obj);

            return Save();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}
