using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemo.Models;
using WebAPIDemo.Models.Repositories;

namespace WebAPIDemo.Filters.ActionFilters
{
    public class Shirt_ValidateShirtidFilterAttribute : ActionFilterAttribute
    {
        override public void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var id = context.ActionArguments["id"] as int?;
            var shirt = context.ActionArguments["shirt"] as Shirt;
            if (id.HasValue)
            {
                if (id.HasValue && shirt != null && id != shirt.ShirtId)
                {
                    context.ModelState.AddModelError("ShirtId", "ShirtId in the route and in the body do not match.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }

            }
        }
    }
}
