using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCreatorTool.Model;

namespace WebsiteCreatorTool.Domain.Contracts
{
    public interface ISampleService
    {
        void CreateSampleData(SampleModel sampleModel);
        SampleModel GetSampleEntityDetailById(int entityId);
        int GetSampleDataById(int id);
    }
}
