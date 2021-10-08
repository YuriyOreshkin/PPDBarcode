using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDBarcode.Services
{
    public interface ITemplateService
    {
        string GetText(string filename);
        //string DisplayBarcodes(string text);
        //string SetParametersValue(string text, List<ParameterItem> values);
        //void Save();

    }
}
