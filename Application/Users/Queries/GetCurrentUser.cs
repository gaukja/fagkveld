using Application.Common.Interfaces;
using MediatR;
using System.Security.Claims;

namespace Application.Users.Queries;
public class GetCurrentUser : IRequest<UserInfoDto>
{
    public class Handler(ICurrentUserService currentUserService) : IRequestHandler<GetCurrentUser, UserInfoDto>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public Task<UserInfoDto> Handle(GetCurrentUser request, CancellationToken cancellationToken)
        {
            var userInfo = new UserInfoDto
            {
                Id = _currentUserService.UserId,
                FullName = _currentUserService.Fullname,
                AzureEntraTenantId = _currentUserService.AzureEntraTenantId,
                Roles = _currentUserService.User?.Claims
                    .Where(claim => claim.Type == ClaimTypes.Role)
                    .Select(claim => claim.Value)
                    .ToList() ?? []
            };

            return Task.FromResult(userInfo);
        }
    }
}
