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
    public class FormsServiceController: Controller
    {
        private IRepositoryService repository;

        public FormsServiceController()
        {
            repository = new StaticRepositoryService();
        }

        //Read
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var forms = repository.GetForms().OrderBy(o=>o.OrderNum).ToList().ToDataSourceResult(request, p => ConvertToViewModel(p));

            return Json(forms);
        }


        private FormViewModel ConvertToViewModel(FormModel model)
        {
           return  new FormViewModel
           {
                Id = model.Id,
                OrderNum = model.OrderNum,
                Name = model.Name,
                Description= model.Description
             
            };
        }

        //public JsonResult ReadEditorsTemplates()
        //{
        //    List<DropDownListItem> editors = new List<DropDownListItem>();

        //    foreach (string editor in repository.GetEditorsTemplates(System.Web.Hosting.HostingEnvironment.MapPath("~/Views/Parameters/EditorTemplates/")))
        //    {
        //        editors.Add(new DropDownListItem { Value = editor, Text = editor });
        //    }

        //    return Json(editors, JsonRequestBehavior.AllowGet);
        //}

        //Create
        //[HttpPost]
        //public ActionResult Create([DataSourceRequest]DataSourceRequest request, ParameterViewModel parameter)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var entity = new ParameterModel();
        //            repository.Create(entity);
        //            parameter.Id = entity.Id;
        //            parameter.OrderNum = entity.OrderNum;
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("parameter", ex.Message);
        //        }
        //    }

        //    return Json(new[] { parameter }.ToDataSourceResult(request, ModelState));

        //}

        //Update
        //[HttpPost]
        //public ActionResult Update([DataSourceRequest]DataSourceRequest request, ParameterViewModel parameter)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var entity = repository.GetParameters().FirstOrDefault(p => p.Id == parameter.Id);
        //            entity = parameter.ToEntity(entity);
        //            repository.Update(entity);
                    
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("parameter", ex.Message);
        //        }
        //    }

        //    return Json(new[] { parameter }.ToDataSourceResult(request, ModelState));

        //}

        //[HttpPost]
        //public JsonResult SetOrder(long id, short step)
        //{

        //    try
        //    {
        //        repository.SetOrder(id, step);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { result = "errors", errors = "Ошибка: " + ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
                

        //        return Json(new { result = "OK" }, JsonRequestBehavior.AllowGet);
         
        //}

        //Delete
        //[HttpPost]
        //public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ParameterViewModel parameter)
        //{
        //    if (ModelState.IsValid)
        //    {
               
        //        try
        //        {
        //            repository.Delete(parameter.Id);

        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("parameter", ex.Message);
        //        }
        //    }

        //    return Json(new[] { parameter }.ToDataSourceResult(request, ModelState));

        //}



    }
}

