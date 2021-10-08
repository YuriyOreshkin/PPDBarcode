using PPDBarcode.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPDBarcode.Models
{
    public class BarcodeViewModel
    {

        [DisplayName("Наименование")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Содержание")]
        [Required]
        public string Value { get; set; }
        [DisplayName("Размер")]
        [DefaultValue(200)]
        [Required]
        public int Size{ get; set; }
  
    }
}