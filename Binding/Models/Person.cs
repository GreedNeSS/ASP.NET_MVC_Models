using Microsoft.AspNetCore.Mvc;

namespace Binding.Models
{
    [Bind("Name")]
    public record class Person(string Name, int Age);
}
