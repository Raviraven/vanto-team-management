using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Vanto.Api.Controllers;

public class BasicController : ControllerBase
{
    protected string ConvertErrorsToString(IEnumerable<Error> errors)
    {
        var errorString = string.Join(", ", errors.Select(n => n.Description));
        return errorString;
    }
}