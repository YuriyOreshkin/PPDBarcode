using PPDBarcode.Models;
using PPDBarcode.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PPDBarcode.Controllers
{
    public class TemplateController : Controller
    {
        private ITemplateService template;

        public TemplateController() {

            template = new TemplateService(); //new TemplateService(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/FormTemplates/Template.html"));
        }
        

        public ActionResult Barcode(BarcodeViewModel barcode)
        {

            return PartialView(barcode);
        }
       



        //
        private string Full(string text)
        {
            
            return text;
        }

        private List<ParameterItem> GetParameters(IDictionary<string,object> parameters)
        {
            List<ParameterItem> values = new List<ParameterItem>();

            foreach (string property in  parameters.Keys)
            {
                    values.Add(new ParameterItem { name = property, value = parameters[property].ToString() });
            }

            return values;
        }

        //[HttpPost]
        //public ActionResult Full()
        //{

        //    //Parameters
        //    Dictionary<string, object> parameters = new Dictionary<string, object>();

        //    foreach (var parameter in Request.Form.AllKeys)
        //    {
        //        parameters[parameter] = Request.Form[parameter];
        //    }

        //    //Replace parameters
        //    //template.SetParametersValue(GetParameters(parameters));

        //    //Barcodes
        //    template.DisplayBarcodes();

        //    return Editor();
        //}

        private string GetFileName(int formId)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/FormTemplates/");
            var name = "Template_" + formId.ToString() + ".html";

            return path + name;

        }

        public ActionResult EditorContent(int formId)
        {

            string text = template.GetText(GetFileName(formId));

            return Content(text);
        }

        public ActionResult Editor(int formId)
        {

            //ViewBag.editorValue = template.GetText(formId);

            string text = template.GetText(GetFileName(formId));

            return PartialView("Editor",text);
        }

        //public ActionResult Save(string data)
        //{
        //    template.text = data;
        //    template.Save();

        //    return new HttpStatusCodeResult(200);
        //}

    }
}