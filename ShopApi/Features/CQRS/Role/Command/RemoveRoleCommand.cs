using ShopApi.DataBaseContext.Repositories.Role;
using ShopApi.Features.CQRS.Role.Outputs;

namespace ShopApi.Features.CQRS.Role.Command;

public sealed class RemoveRoleCommand : IRequest<RoleResponse>
{
    public Guid Id { get; set; }
    
    private sealed class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommand, RoleResponse>
    {
        private readonly IRoleRepository _roleRepository;

        public RemoveRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleResponse> Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _roleRepository.Remove(request.Id);

            return new RoleResponse(result);
        }
    }
    
    public sealed class RemoveRoleCommandValidator: AbstractValidator<RemoveRoleCommand>
    {
        public RemoveRoleCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}