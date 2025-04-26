using Microsoft.AspNetCore.Mvc;
using XPE.SoftwareArch.FinalChallenge.Api.Models.Extensions;
using XPE.SoftwareArch.FinalChallenge.Application.Exceptions;
using XPE.SoftwareArch.FinalChallenge.Domain.Exceptions;

namespace XPE.SoftwareArch.FinalChallenge.Api.Helpers;

public static class ActionResultHelper
{
    public static async Task<ActionResult> ExecuteWithHandlingAsync(Func<Task<ActionResult>> action)
    {
        try
        {
            return await action();
        }
        catch (NotFoundException ex)
        {
            return new NotFoundObjectResult(ex.ToViewModel());
        }
        catch (EntityValidationException ex)
        {
            return new ConflictObjectResult(ex.ToViewModel());
        }
        catch (DataBaseException ex)
        {
            return new BadRequestObjectResult(ex.ToViewModel());
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.ToViewModel());
        }
    }
}
