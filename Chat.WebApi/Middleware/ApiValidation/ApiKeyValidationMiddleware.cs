namespace Chat.WebApi.Middleware.ApiValidation;

public class ApiKeyValidationMiddleware {

    public ApiKeyValidationMiddleware(RequestDelegate next) {
        _next = next;
    }


    private RequestDelegate _next;


    public async Task InvokeAsync(HttpContext context) {

        ApiValidator apiValidator = new ApiValidator(context);
        Boolean isValid = await apiValidator.Validate();

        if(!isValid)
            return;

        await _next(context);
    }
}

