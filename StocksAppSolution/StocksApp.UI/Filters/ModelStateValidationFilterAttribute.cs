using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StocksApp.UI.Controllers;

namespace StocksApp.UI.Filters;

public class ModelStateValidationFilterAttribute : ActionFilterAttribute
{

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //before logic
        if (!context.ModelState.IsValid)
        {
            context.Result = new RedirectToActionResult(nameof(TradeController.Index), "Trade", null);
            return;
        }

        await next();
        //after logic
    }

}
