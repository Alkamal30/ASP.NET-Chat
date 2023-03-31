namespace Chat.WebApi.Middleware.ApiValidation;

public class ApiValidator {

	public ApiValidator(HttpContext context) {
		_context = context;
	}


	public static readonly String ApiKeyName = "ApiKey";

	private readonly HttpContext _context;


	public async Task<Boolean> Validate() {

		if(!_context.Request.Headers.TryGetValue(ApiKeyName, out var requestApiKey)) {
			await PrepareResponse("Api Key was not provided!");
			return false;
		}

		var configuration = _context.RequestServices.GetRequiredService<IConfiguration>();
		var apiKey = configuration.GetValue<String>(ApiKeyName);

		if(apiKey != requestApiKey) {
			await PrepareResponse("Api Key is not valid!");
			return false;
		}

		return true;
	}

	private async Task PrepareResponse(String content) {
		_context.Response.StatusCode = StatusCodes.Status401Unauthorized;
		await _context.Response.WriteAsync(content);
	}
}
