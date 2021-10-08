using PPDBarcode.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPDBarcode.Models
{
    public class FormViewModel
    {
        public int Id { get; set; }
        [Required]
        public short OrderNum { get; set; }
        [DisplayName("Наименование")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Описание")]
        [Required]
        public string Description { get; set; }
        
    }
}