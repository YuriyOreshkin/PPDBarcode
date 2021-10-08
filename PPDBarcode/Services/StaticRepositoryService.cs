using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PPDBarcode.Services
{
    public class StaticRepositoryService : IRepositoryService
    {
        private List<FormModel> forms;

        public StaticRepositoryService()
        {
            forms = new List<FormModel>
            {
                new FormModel
                {
                     Id =1,
                    OrderNum = 1,
                    Name="ДСВ",
                    Description ="для уплаты дополнительных страховых взносов",
                    Parameters = new List<ParameterModel>
                    {
                    new ParameterModel{

                        Id =1,
                        Name="SNILS",
                        Label ="СНИЛС",
                        Required =true,
                        Hide=false,
                        EditorTemplate="SNILS"

                    },

                    new ParameterModel {
                        Id =2,
                        Name="FIO",
                        Label ="Ф.И.О.",
                        Required =true,
                        Hide=false,
                        EditorTemplate="String"
                    },

                    new ParameterModel {
                        Id = 3,
                        Name ="INN",
                        Label ="ИНН",
                        Required =true,
                        Hide=false,
                        EditorTemplate="Number",
                        DefaultValue = "32143544655767"

                    },

                     new ParameterModel {
                        Id = 4,
                        Name ="Date",
                        Label ="Дата",
                        Required =true,
                        Hide=false,
                        EditorTemplate="Date"
                        //DefaultValue = "25.01.2021"

                    }
                    }
                },

                 new FormModel {
                    Id =2,
                    OrderNum = 2,
                    Name="ОМС",
                    Description ="обязательного медицинского страхования",
                }
            };
        
        }

      

        public List<string> GetEditorsTemplates(string directory)
        {
            List<string> result = new List<string>();

            foreach (string filename in Directory.EnumerateFiles(directory, "*.cshtml", SearchOption.TopDirectoryOnly))
            {
                result.Add(Path.GetFileNameWithoutExtension(filename));
            }

            return result;
        }


        public IQueryable<FormModel> GetForms()
        {
            return forms.AsQueryable();
        }

        public IQueryable<ParameterModel> GetParameters(int formId)
        {
            var form = GetForms().FirstOrDefault(f => f.Id == formId);
            if (form != null)
                return form.Parameters.AsQueryable();
            

            return Enumerable.Empty<ParameterModel>().AsQueryable();
            
        }

        public void SetParameterOrder(int formId,short Id, short step)
        {
            ParameterModel entityFrom = GetParameters(formId).FirstOrDefault(p => p.Id == Id);

            if (entityFrom != null)
            {
                ParameterModel entityTo = GetParameters(formId).FirstOrDefault(p => p.Id == entityFrom.Id + step);

                if (entityTo != null)
                {
                    entityFrom.Id = (short)(entityFrom.Id + step);
                    entityTo.Id = (short)(entityTo.Id - step);

                }
            }
            else {

                throw new Exception("Параметр не обнаружен!"); 
            
            }
        }

        public void CreateParameter(int formId, ParameterModel model)
        {
            var form = GetForms().FirstOrDefault(f => f.Id == formId);
            if (form != null)
            {
               model.Id = (short)(form.Parameters.Max(p => p.Id) + 1);
               form.Parameters.Add(model);
            }
        }

        public void UpdateParameter(int formId, ParameterModel model)
        { 
            if (model == null)
            { 

                throw new Exception("Параметр не обнаружен!");

            }
        }

        public void DeleteParameter(int formId,int Id)
        {
            var form = GetForms().FirstOrDefault(f => f.Id == formId);
            if (form != null)
            {
                var parameter = GetParameters(form.Id).FirstOrDefault(p => p.Id == Id);
                if (parameter != null)
                {

                    form.Parameters.Remove(parameter);
                }
            }
        }
    }
}