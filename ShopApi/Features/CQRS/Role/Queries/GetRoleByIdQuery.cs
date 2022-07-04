using ShopApi.DataBaseContext.Repositories.Role;
using ShopApi.Features.CQRS.Role.Outputs;

namespace ShopApi.Features.CQRS.Role.Queries;

public sealed class GetRoleByIdQuery : IRequest<RoleResponse>
{
    public Guid Id { get; set; }
    
    private sealed class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleResponse>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleByIdQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleResponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _roleRepository.GetById(request.Id);

            return new RoleResponse(result);
        }
    }
    
    public sealed class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
    {
        public GetRoleByIdQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}