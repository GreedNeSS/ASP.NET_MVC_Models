using ModelBinder.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options =>
{
    //options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
    options.ModelBinderProviders.Insert(0, new EventModelBinderProvider());
});
var app = builder.Build();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{Id?}");

app.Run();
