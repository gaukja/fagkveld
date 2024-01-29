using Application.Admin;
using Application.Admin.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fagkveld.Api.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<SecretInfoDto>> GetAdminInfo(CancellationToken cancellationToken = default)
    {
        return await Mediator.Send(new GetAdminInfo(), cancellationToken);
    }
}