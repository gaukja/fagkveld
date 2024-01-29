namespace Application.Users;

public record UserInfoDto
{
    public required string? Id { get; init; }
    public required string? FullName { get; init; }
    public required IEnumerable<string> Roles { get; init; }
    public required string? AzureEntraTenantId { get; init; }
}