using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sinqia.Calculator.Application.Exceptions;
using Sinqia.Calculator.Domain.Dtos.Responses;

namespace Sinqia.Calculator.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is ExceptionBase myRecipeBookException)
            HandleProjectException(myRecipeBookException, context);
        else
            ThrowUnknowException(context);
    }

    private static void HandleProjectException(ExceptionBase myRecipeBookException, ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)myRecipeBookException.GetStatusCode();
        context.Result = new ObjectResult(new ResponseErrorJson(myRecipeBookException.GetErrorMessages()));
    }

    private static void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson("ERRO INESPERADO"));
    }
}