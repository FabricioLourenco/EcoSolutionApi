namespace EcoSolutionApi.Middlewares
{
    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKey(
          this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}
