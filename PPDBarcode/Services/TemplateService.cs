using PPDBarcode.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PPDBarcode.Services
{
    public class TemplateService : ITemplateService
    {


        //Text
        public string GetText(string filename)
        {
            return Read(filename);
        }

        /// <summary>
        /// Read data from file
        /// </summary>
        private string Read(string filename)
        {
            if (File.Exists(filename))
                return File.ReadAllText(filename);

            return String.Empty;
        }


        /* public void SetParametersValue(List<ParameterItem>  values)
         {
             foreach (ParameterItem parameter in GetParameters())
             {
                 var value = values.FirstOrDefault(p => p.name == parameter.name);
                 if (value != null) {

                     text = text.Replace(parameter.value, value.value);
                 }
             }
         }


         public void DisplayBarcodes()
         {
             foreach (BarcodeModel barcode in GetBarcodes())
             {
                 var value = @"<div class='barcode' id=" + barcode.Name +  " size=" + barcode.Size + ">"+  barcode.Value +"</div>";

                 text = text.Replace(barcode.ToString(), value);

             }
         }


         private List<BarcodeModel> GetBarcodes()
         {
             List<BarcodeModel> result = new List<BarcodeModel>();
             string template = text;
             //barcode(Name=name;Value=value;Size=100)
             var symbol = "barcode(";

             while (template.Contains(symbol))
             {
                 int startIndex = template.IndexOf(symbol);
                 int lastIndex = template.IndexOf(")", startIndex) + 1;
                 if (lastIndex > -1)
                 {
                     string barcode_properties = template.Substring(startIndex, lastIndex - startIndex);

                     result.Add(new BarcodeModel { Name =GetBarcodePropertyValue(barcode_properties, "Name"), Value = GetBarcodePropertyValue(barcode_properties, "Value"), Size=int.Parse(GetBarcodePropertyValue(barcode_properties, "Size")) });

                 }
                 else
                 {
                     lastIndex = startIndex + symbol.Length + 1;

                 }

                 template = template.Substring(lastIndex, template.Length - lastIndex);
             }

                 return result;
         }

     private string GetBarcodePropertyValue(string barcode ,string property)
     {
         var startIndex = barcode.IndexOf(property + "=");
         var lastIndex = barcode.IndexOf(";", startIndex);
         if (lastIndex < 0)
         {
             lastIndex = barcode.IndexOf(")", startIndex);
         }

             startIndex = startIndex + property.Length + 1;

         var  value =barcode.Substring(startIndex, lastIndex-startIndex);

         return value;
     }

     private List<ParameterItem> GetParameters()
         {
             List<ParameterItem> result = new List<ParameterItem>();

             string template = text;
             //parameter(Name)
             var symbol = "parameter";

             while (template.Contains(symbol))
             {
                 int startIndex = template.IndexOf(symbol);
                 int lastIndex = template.IndexOf(")", startIndex) + 1;
                 if (lastIndex > -1)
                 {
                     string parameter = template.Substring(startIndex, lastIndex - startIndex);

                     if (!parameter.Contains(" "))
                     {
                         string name = parameter.Substring(parameter.IndexOf("(") + 1, parameter.IndexOf(")") - parameter.IndexOf("(") -1);
                         result.Add(new ParameterItem { name = name, value=parameter });
                     }
                     else
                     {
                         lastIndex = startIndex + symbol.Length + 1;
                     }
                 }
                 else
                 {
                     lastIndex = startIndex + symbol.Length + 1;

                 }

                 template = template.Substring(lastIndex, template.Length - lastIndex);
             }

             return result;
         }


         /// <summary>
         /// Save data to file
         /// </summary>
         public void Save(string filename)
         {
             string html = HttpUtility.HtmlDecode(text);

             using (StreamWriter file = new StreamWriter(filename, false))
             {
                 file.WriteLine(html);
             }
         }*/
    }
}