using Application.Common.Interfaces;
using System.Security.Claims;

namespace Fagkveld.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.Name)?.ToLower();
        UserId ??= httpContextAccessor?.HttpContext?.User?.FindFirstValue("preferred_username")?.ToLower();
        UserId ??= httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)?.ToLower();

        Fullname = httpContextAccessor?.HttpContext?.User?.FindFirstValue("name");
        IsAuthenticated = UserId != null;

        User = httpContextAccessor?.HttpContext?.User;

        if (User != null && User.Identity is ClaimsIdentity identity)
        {
            AzureEntraTenantId = identity.Claims
                .FirstOrDefault(x => x.Type.Equals("http://schemas.microsoft.com/identity/claims/tenantid")
                    || x.Type == "tid")?.Value;
        }
    }
    public string? UserId { get; }

    public string? Fullname { get; }

    public bool IsAuthenticated { get; }

    public string? AzureEntraTenantId { get; }

    public ClaimsPrincipal? User { get; }
}
