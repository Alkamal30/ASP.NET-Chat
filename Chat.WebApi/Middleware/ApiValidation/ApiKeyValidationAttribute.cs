using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;

namespace Chat.WebApi.Middleware.ApiValidation;

public class ApiKeyValidationAttribute : Attribute, IAsyncActionFilter {

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {

        ApiValidator apiValidator = new ApiValidator(context.HttpContext);
        Boolean isValid = await apiValidator.Validate();

        if(!isValid)
            return;

        await next();
    }
}
