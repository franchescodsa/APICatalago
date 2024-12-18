using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APICatalogo.Filters
{
    // Filtro de ação personalizadocom IExceptionFilter
    public class ApiExceptionFilter : IExceptionFilter
    {

        private readonly ILogger<ApiExceptionFilter> _logger;
        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Ocorreu uma exceçção na tratativa : Status Code 500");

            context.Result = new ObjectResult("Ocorreu umproblema ao tratar a sua solicitação : Saus code")
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }
    }
}
