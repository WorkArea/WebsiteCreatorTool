using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebsiteCreatorTool.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteCreatorTool.Data.Sql
{
    public class WebsiteCreatorToolDbContext: DbContext, IUnitOfWork
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly",
        Justification = "Inherited from IDbContext interface, which exists to support using.")]
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetupSampleEntity(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void SetupSampleEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SampleEntity>().ToTable("SampleTable");
            modelBuilder.Entity<SampleEntity>().HasKey(u => u.SampleId);
            modelBuilder.Entity<SampleEntity>().Property(u => u.SampleId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        public DbSet<SampleEntity> SampleEntity { get; set; }

        /// <summary>
        /// Allows saving changes via the IUnitOfWork interface.
        /// </summary>
        void IUnitOfWork.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
