using PPDBarcode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPDBarcode.Controllers
{
    public class ParametersController : Controller
    {
        public ActionResult List(int formId)
        {
            return PartialView(formId);
        }
       
    }
}