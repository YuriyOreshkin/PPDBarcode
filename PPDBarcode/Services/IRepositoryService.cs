
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDBarcode.Services
{
    public interface IRepositoryService
    {
        IQueryable<FormModel> GetForms();
        IQueryable<ParameterModel> GetParameters(int formId);
        void SetParameterOrder(int formId, short Id, short step);
        void CreateParameter(int formId, ParameterModel model);
        void UpdateParameter(int formId, ParameterModel model);
        void DeleteParameter(int formId, int Id);
        List<string> GetEditorsTemplates(string directory);

    }
}
