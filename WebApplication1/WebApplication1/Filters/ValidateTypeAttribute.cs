using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;
using WebApplication1.ViewModel;

namespace WebApplication1.Filters;

public class ValidateTypeAttribute:ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var AllowedTypeRegex = new Regex("^(Electric|Gas|Diesel|Hybrid)$");

        Car? car = context.ActionArguments["input"] as Car;

        if (car is null || !AllowedTypeRegex.IsMatch((car.Type)))
        {
            context.Result = new BadRequestObjectResult(new { Error = "invalid Type name" });
        }

    }

}
