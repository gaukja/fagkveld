namespace Application.Common.Interfaces;
public interface ICurrentUserService
{
    string? UserId { get; }

    string? Fullname { get; }

    bool IsAuthenticated { get; }

    string? AzureEntraTenantId { get; }

    System.Security.Claims.ClaimsPrincipal? User { get; }
}
