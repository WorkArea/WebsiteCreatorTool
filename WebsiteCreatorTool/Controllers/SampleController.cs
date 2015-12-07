using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteCreatorTool.Domain.Contracts;
using WebsiteCreatorTool.Model;

namespace WebsiteCreatorTool.WebUI.Controllers
{
    public class SampleController : Controller
    {
        #region Variable

        private readonly ISampleService _sampleService = null;

        #endregion Variable


        #region EntryPoint

        public SampleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        #endregion EntryPoint


        #region Action Methods

        public ActionResult Index()
        {
            try
            {
                int result = _sampleService.GetSampleDataById(1);

                _sampleService.GetSampleEntityDetailById(1);

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Add(string id)
        {
            try
            {
                SampleModel sampleModel = new SampleModel();
                sampleModel.ForeignId = 1;
                sampleModel.Title = "First Test";

                _sampleService.CreateSampleData(sampleModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        #endregion Action Methods


        #region AJAX Methods

        public JsonResult GetJSONData()
        {
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Methods
    }
}