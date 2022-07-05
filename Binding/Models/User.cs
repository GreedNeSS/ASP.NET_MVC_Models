using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Binding.Models
{
    public class User
    {
        public int Id { get; set; }
        [BindRequired]
        public string Name { get; set; } = "";
        [BindingBehavior(BindingBehavior.Required)]
        public int Age { get; set; }
        [BindNever]
        public bool HasRight { get; set; }
    }
}
