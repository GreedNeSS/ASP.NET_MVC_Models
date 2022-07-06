using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace ModelBinder.Infrastructure
{
    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            ILoggerFactory loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
            IModelBinder modelBinder = new DateTimeModelBinder(new SimpleTypeModelBinder(typeof(DateTime), loggerFactory));
            return context.Metadata.ModelType == typeof(DateTime) ? modelBinder : null;
        }
    }
}
