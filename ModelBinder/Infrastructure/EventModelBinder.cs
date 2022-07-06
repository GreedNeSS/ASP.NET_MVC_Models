using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBinder.Models;

namespace ModelBinder.Infrastructure
{
    public class EventModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var datePartVaalues = bindingContext.ValueProvider.GetValue("date");
            var timePartVaalues = bindingContext.ValueProvider.GetValue("time");
            var namePartVaalues = bindingContext.ValueProvider.GetValue("name");


            string? date = datePartVaalues.FirstValue;
            string? time = timePartVaalues.FirstValue;
            string? name = namePartVaalues.FirstValue;
            Guid id = Guid.NewGuid();

            if (string.IsNullOrEmpty(name))
            {
                name = "Неизвестное событие";
            }

            DateTime.TryParse(date, out DateTime parsedDateValue);
            DateTime.TryParse(time, out DateTime parsedTimeValue);

            var eventDate = new DateTime(
                parsedDateValue.Year,
                parsedDateValue.Month,
                parsedDateValue.Day,
                parsedTimeValue.Hour,
                parsedTimeValue.Minute,
                parsedTimeValue.Second);

            bindingContext.Result = ModelBindingResult.Success(new Event { Id = id, Name = name, EventDate = eventDate });
            return Task.CompletedTask;
        }
    }
}
