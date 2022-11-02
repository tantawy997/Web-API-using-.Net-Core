using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Valdation
{
    public class CreatedDateValdationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {

            return value is DateTime CreatedDate && CreatedDate <= DateTime.Now;

        }
    }
}
