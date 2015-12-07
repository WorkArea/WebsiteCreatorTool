using WebsiteCreatorTool.Data.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCreatorTool.Data.Sql.Seed
{
    public partial class DbContextSeedData : ISeedDatabase
    {
        public void Seed()
        {
            this.SeedMasterData();
            //this.SaveChanges();            
        }

        void SeedMasterData()
        {
            //this.Countries.Add(new Country() { Name = "Afghanistan" });
        }
    }
}
