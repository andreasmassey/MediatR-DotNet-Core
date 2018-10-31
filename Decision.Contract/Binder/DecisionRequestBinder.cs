using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Decision.Contract.Features;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Decision.Contract.Binder
{
    public class DecisionRequestBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            try
            {
                var body = bindingContext.ActionContext.HttpContext.Request.Body;
                var encoding = Encoding.UTF8;
                var model = new GetDecisionContract.Request();

                using (StreamReader reader = new StreamReader(body, encoding))
                {
                    string jsonResult;
                    jsonResult = reader.ReadToEnd();
                    model = JsonConvert.DeserializeObject<GetDecisionContract.Request>(jsonResult);
                }

                bindingContext.Result = ModelBindingResult.Success(model);
                return Task.CompletedTask;
            }
            catch (Exception exception)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.FromException(exception);
            }
        }
    }
}
