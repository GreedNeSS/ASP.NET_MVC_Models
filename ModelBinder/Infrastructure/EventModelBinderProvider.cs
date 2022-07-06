using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBinder.Models;

namespace ModelBinder.Infrastructure
{
    public class EventModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder _modelBinder = new EventModelBinder();

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(Event) ? _modelBinder : null;
        }
    }
}
