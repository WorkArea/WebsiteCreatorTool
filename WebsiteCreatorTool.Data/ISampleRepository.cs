using WebsiteCreatorTool.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCreatorTool.Data
{
    public interface ISampleRepository
    {
        void CreateSampleData(SampleEntity sampleEntity);

        SampleEntity GetSampleEntityDetailById(int entityId);

        void Update(SampleEntity sample);

        void Delete(int entityId);
    }
}
