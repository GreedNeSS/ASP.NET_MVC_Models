using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBinder.Infrastructure
{
    public class DateTimeModelBinder : IModelBinder
    {
        private readonly IModelBinder _binder;

        public DateTimeModelBinder(IModelBinder modelBinder)
        {
            _binder = modelBinder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var datePartVaalues = bindingContext.ValueProvider.GetValue("date");
            var timePartVaalues = bindingContext.ValueProvider.GetValue("time");

            if (datePartVaalues == ValueProviderResult.None || timePartVaalues == ValueProviderResult.None)
            {
                return _binder.BindModelAsync(bindingContext);
            }

            string? date = datePartVaalues.FirstValue;
            string? time = timePartVaalues.FirstValue;

            DateTime.TryParse(date, out DateTime parsedDateValue);
            DateTime.TryParse(time, out DateTime parsedTimeValue);

            var result = new DateTime(
                parsedDateValue.Year,
                parsedDateValue.Month,
                parsedDateValue.Day,
                parsedTimeValue.Hour,
                parsedTimeValue.Minute,
                parsedTimeValue.Second);

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
