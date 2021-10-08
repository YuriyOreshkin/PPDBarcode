using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PPDBarcode.Models;
using PPDBarcode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPDBarcode.Controllers
{
    public class ParametersServiceController : Controller
    {
        private IRepositoryService repository;
        public ParametersServiceController()
        {
            repository = new StaticRepositoryService();
        }

        //Read
        public ActionResult Read([DataSourceRequest] DataSourceRequest request, int formId)
        {
            var parameters = repository.GetParameters(formId).OrderBy(o=>o.Id).ToList().ToDataSourceResult(request, p => ConvertToViewModel(p));

            return Json(parameters);
        }


        private ParameterViewModel ConvertToViewModel(ParameterModel model)
        {
           return  new ParameterViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Label = model.Label,
                Required = model.Required,
                EditorTemplate = model.EditorTemplate,
                Hide = model.Hide,
                DefaultValue = model.DefaultValue

            };
        }

        public JsonResult ReadEditorsTemplates()
        {
            List<DropDownListItem> editors = new List<DropDownListItem>();

            foreach (string editor in repository.GetEditorsTemplates(System.Web.Hosting.HostingEnvironment.MapPath("~/Views/Parameters/EditorTemplates/")))
            {
                editors.Add(new DropDownListItem { Value = editor, Text = editor });
            }

            return Json(editors, JsonRequestBehavior.AllowGet);
        }

        //Create
        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, int formId, ParameterViewModel parameter)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = new ParameterModel();
                    repository.CreateParameter(formId, entity);
                    parameter.Id = entity.Id;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("parameter", ex.Message);
                }
            }

            return Json(new[] { parameter }.ToDataSourceResult(request, ModelState));

        }

        //Update
        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, int formId, ParameterViewModel parameter)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = repository.GetParameters(formId).FirstOrDefault(p => p.Id == parameter.Id);
                    entity = parameter.ToEntity(entity);
                    repository.UpdateParameter(formId,entity);
                    
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("parameter", ex.Message);
                }
            }

            return Json(new[] { parameter }.ToDataSourceResult(request, ModelState));

        }

        [HttpPost]
        public JsonResult SetOrder(int formId,short Id, short step)
        {

            try
            {
                repository.SetParameterOrder(formId, Id, step);
            }
            catch (Exception ex)
            {
                return Json(new { result = "errors", errors = "Ошибка: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
                

                return Json(new { result = "OK" }, JsonRequestBehavior.AllowGet);
         
        }

        //Delete
        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, int formId, ParameterViewModel parameter)
        {
            if (ModelState.IsValid)
            {
               
                try
                {
                    repository.DeleteParameter(formId,parameter.Id);

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("parameter", ex.Message);
                }
            }

            return Json(new[] { parameter }.ToDataSourceResult(request, ModelState));

        }


        public ActionResult Input(int? formId)
        {
            var id = formId.HasValue ? (int)formId : 0;

            var parameters = repository.GetParameters(id).ToList().Select(p => ConvertToViewModel(p));
            return PartialView("~/Views/Parameters/Input.cshtml", parameters);
        }

    }
}

