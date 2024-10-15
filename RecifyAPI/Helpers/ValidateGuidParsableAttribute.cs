using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace RecifyAPI.Helpers;

public class ValidateGuidParsableAttribute : ActionFilterAttribute
{
    private readonly string _parameterName;

    public ValidateGuidParsableAttribute(string parameterName)
    {
        _parameterName = parameterName;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.TryGetValue(_parameterName, out var argument))
        {
            var parameterValue = argument as string;
            if (!Guid.TryParse(parameterValue, out var parsedGuid))
            {
                context.Result = new BadRequestObjectResult($"{_parameterName} must be a valid GUID");
            }
        }
        else
        {
            context.Result = new BadRequestObjectResult($"{_parameterName} parameter is missing");
        }

        base.OnActionExecuting(context);
    }
}