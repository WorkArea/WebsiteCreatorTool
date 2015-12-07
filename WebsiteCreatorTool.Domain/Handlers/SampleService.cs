using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCreatorTool.Data;
using WebsiteCreatorTool.Data.Entities;
using WebsiteCreatorTool.Domain.Contracts;
using WebsiteCreatorTool.Model;

namespace WebsiteCreatorTool.Domain.Handlers
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            if (sampleRepository == null) throw new ArgumentNullException("ISampleRepository in SampleService Class");

            _sampleRepository = sampleRepository;
        }

        public int GetSampleDataById(int id)
        {
            return 1;
        }

        public void CreateSampleData(SampleModel sampleModel)
        {
            try
            {
                //Rather Than Explicit Converson Impliment Automapper
                SampleEntity sampleEntity = new SampleEntity();
                sampleEntity.SampleId = sampleModel.SampleId;
                sampleEntity.ForeignId = sampleModel.ForeignId;
                sampleEntity.Title = sampleModel.Title;

                _sampleRepository.CreateSampleData(sampleEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SampleModel GetSampleEntityDetailById(int entityId)
        {
            try
            {
                SampleEntity sampleEntity = _sampleRepository.GetSampleEntityDetailById(entityId);

                //Rather Than Explicit Converson Impliment Automapper

                SampleModel sampleModel = new SampleModel();
                sampleModel.SampleId = sampleEntity.SampleId;
                sampleModel.ForeignId = sampleEntity.ForeignId;
                sampleModel.Title = sampleEntity.Title;
                return sampleModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
