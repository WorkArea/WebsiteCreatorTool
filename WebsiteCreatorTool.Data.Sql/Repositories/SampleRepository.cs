using WebsiteCreatorTool.Data.Entities;
using WebsiteCreatorTool.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WebsiteCreatorTool.Data.Sql.Repositories
{
    public class SampleRepository : BaseRepository, ISampleRepository
    {
        public SampleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public void CreateSampleData(SampleEntity sampleEntity)
        {
            try
            {
                this.GetDbSet<SampleEntity>().Add(sampleEntity);
                this.UnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SampleEntity GetSampleEntityDetailById(int entityId)
        {
            try
            {
                return this.GetDbSet<SampleEntity>()
                    .Where(v => v.SampleId == entityId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(SampleEntity sample)
        {
            try
            {
                this.GetDbSet<SampleEntity>().Attach(sample);
                this.SetEntityState(sample, sample.SampleId == 0 ? EntityState.Added : EntityState.Modified);
                this.UnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int entityId)
        {
            try
            {
                SampleEntity reminderToDelete = this.GetSampleEntityDetailById(entityId);
                this.GetDbSet<SampleEntity>().Remove(reminderToDelete);
                this.UnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
