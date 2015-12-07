using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebsiteCreatorTool.Core;

namespace WebsiteCreatorTool.Data.Sql
{
    public abstract class BaseRepository
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected WebsiteCreatorToolDbContext Context
        {
            get { return (WebsiteCreatorToolDbContext)this.UnitOfWork; }
        }

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            this.UnitOfWork = unitOfWork;
        }

        protected virtual DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return this.Context.Set<TEntity>();
        }

        protected virtual void SetEntityState(object entity, EntityState entityState)
        {
            this.Context.Entry(entity).State = entityState;
        }

        /// <summary>
        /// Map DataReader to Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        protected static List<T> DataReaderMapToList<T>(IDataReader dataReader)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dataReader.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dataReader[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dataReader[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        /// <summary>
        /// Map DataReader to Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        protected static T DataReaderMapToModel<T>(IDataReader dataReader)
        {
            T retVal = default(T);
            
            retVal = Activator.CreateInstance<T>();
            while (dataReader.Read())
            {
                foreach (PropertyInfo prop in retVal.GetType().GetProperties().Where(p => !p.IsMarkedWith<DoNotIncludeAttribute>()))
                {
                    if (!object.Equals(dataReader[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(retVal, dataReader[prop.Name], null);
                    }
                }
            }
            return retVal;
        }       
    }
}
