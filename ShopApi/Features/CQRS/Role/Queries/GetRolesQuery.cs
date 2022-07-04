using ShopApi.DataBaseContext.Repositories.Role;
using ShopApi.Features.CQRS.Role.Outputs;
using ShopApi.Models;

namespace ShopApi.Features.CQRS.Role.Queries;

public sealed class GetRolesQuery : IRequest<DataWithTotal<RoleResponse>>
{
    private sealed class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, DataWithTotal<RoleResponse>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRolesQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<DataWithTotal<RoleResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var result = await _roleRepository.GetAll();
            var roles = result.Select(r => new RoleResponse(r));
            return new DataWithTotal<RoleResponse>(roles);
        }
    }
}