using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCreatorTool.Data.Sql.Initializers
{
    /// <summary>
    /// Initializes the repository for SQLCE
    /// </summary>
    public class RepositoryInitializer : IRepositoryInitializer
    {
        private IUnitOfWork unitOfWork;

        public RepositoryInitializer(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            this.unitOfWork = unitOfWork;

            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");

            //// Sets the default database initialization code for working with Sql Server Compact databases
            //Database.SetInitializer(new DropCreateIfModelChangesSqlCeInitializer<WebsiteCreatorToolDbContext>());
        }

        protected WebsiteCreatorToolDbContext Context
        {
            get { return (WebsiteCreatorToolDbContext)this.unitOfWork; }
        }

        public void Initialize()
        {
                        
        }
    }
}
