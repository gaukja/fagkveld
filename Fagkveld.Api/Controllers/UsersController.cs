using Application.Users;
using Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Fagkveld.Api.Controllers;

public class UsersController : BaseController
{
    [HttpGet("me")]
    public async Task<ActionResult<UserInfoDto>> GetCurrentUser(CancellationToken cancellationToken = default)
    {
        return await Mediator.Send(new GetCurrentUser(), cancellationToken);
    }
}