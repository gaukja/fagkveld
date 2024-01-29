using Application.Common.Interfaces;
using MediatR;

namespace Application.Admin.Queries;
public class GetAdminInfo : IRequest<SecretInfoDto>
{
    public class Handler(ICurrentUserService currentUserService) : IRequestHandler<GetAdminInfo, SecretInfoDto>
    {
        public Task<SecretInfoDto> Handle(GetAdminInfo request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new SecretInfoDto { Name = currentUserService.Fullname! });
        }
    }
}
