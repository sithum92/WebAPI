using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPIDemo.Filters
{
    public class Shirt_ValidateCreateShirtFilterAttribute:ActionFilterAttribute
    {
        override public void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirt = context.ActionArguments["shirt"];

            if (shirt == null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt is invalid.");
            }

        }
    }
}
