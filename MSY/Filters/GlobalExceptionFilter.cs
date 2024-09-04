using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MSY.Infrastructure.Exceptions;

namespace MSY.Filters;

public class GlobalExceptionFilter: ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        JsonResult result;

        if (context.Exception is MsyServiceException serviceException)
        {
            var resultObject = new
            {
                serviceException.Message,
            };
            result = new JsonResult(resultObject)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        else
        {
            var resultObject = new
            {
                context.Exception.Message,
            };
            result = new JsonResult(resultObject)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        context.Result = result;
    }
}