using System;
using System.Globalization;
using System.Web.Mvc;

namespace WebApp.Binders
{
    public class DateTimeBinder : IModelBinder
    {

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueResult == null)
                return null;

            // Have to do this in order for the entered value to appear in the view if validation fails
            bindingContext.ModelState[bindingContext.ModelName] = new ModelState {Value = valueResult};

            DateTime result;
            if (!DateTime.TryParseExact(valueResult.AttemptedValue, "d.MM.YYYY", null, DateTimeStyles.None, out result))
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Ugyldig datoformat oppgitt");
                return null;
            }
            return result;
        }
    }
}