using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace PPDBarcode.Services
{
    public class ParameterModel
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public bool Required { get; set; }
        public string DefaultValue { get; set; }
        public string EditorTemplate { get; set; }
        public bool Hide { get; set; }
    }
}