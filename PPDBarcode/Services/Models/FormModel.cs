using PPDBarcode.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPDBarcode.Services
{
    public class FormModel
    {
        public FormModel()
        {
            Parameters = new HashSet<ParameterModel>();
        }
        public int Id { get; set; } 
        public short OrderNum { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ParameterModel> Parameters { get; set; }


    }
}