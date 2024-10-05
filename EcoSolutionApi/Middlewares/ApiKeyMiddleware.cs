using EcoSolution.Domain.Interface.Application.Services;
using System.Net;

namespace EcoSolutionApi.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            if (!httpContext.Request.Headers.Keys.Contains("x-api-key", StringComparer.InvariantCultureIgnoreCase))
            {
                await NotFoundResponse(httpContext);
                return;
            }

            var _autenticacaoService = httpContext.RequestServices.GetService<IAutenticacaoService>();
            httpContext.Request.Headers.TryGetValue("x-api-key", out var apiKey);
            var existeChaveAcesso = _autenticacaoService.ExisteChaveDeAcesso(apiKey);
            if (!existeChaveAcesso)
            {
                await UnauthorizedResponse(httpContext);
                return;
            }

            await _next(httpContext);
        }

        private static async Task NotFoundResponse(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            await context.Response.WriteAsync("Api Key não localizada.");
        }

        private static async Task UnauthorizedResponse(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            await context.Response.WriteAsync("Api Key inválida.");
        }
    }
}
