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
    public class FormsController: Controller
    {


        public ActionResult Details(FormViewModel form)
        {

            return PartialView(form);
        }



    }
}

