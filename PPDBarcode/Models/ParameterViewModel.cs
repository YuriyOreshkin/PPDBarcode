using PPDBarcode.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPDBarcode.Models
{
    public class ParameterViewModel
    {
        [DisplayName("№ п/п")]
        public int Id { get; set; }
        [DisplayName("Наименование")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Описание")]
        [Required]
        public string Label { get; set; }
        [DisplayName("Обязательный?")]
        public bool Required { get; set; }
        [DisplayName("Значение по умолчанию")]
        public string DefaultValue { get; set; }
        [DisplayName("Шаблон")]
        [Required]
        public string EditorTemplate { get; set; }
        [DisplayName("Скрывать?")]
        public bool Hide { get; set; }

        public ParameterModel ToEntity(ParameterModel model)
        {
            model.Name = this.Name;
            model.Label = this.Label;
            model.Required = this.Required;
            model.EditorTemplate = this.EditorTemplate;
            model.Hide = this.Hide;
            model.DefaultValue = this.DefaultValue;

            return model;
        }
    }
}