using ShopApi.DataBaseContext.Repositories.Role;
using ShopApi.Features.CQRS.Role.Outputs;

namespace ShopApi.Features.CQRS.Role.Command;

public sealed class AddRoleCommand : IRequest<RoleResponse>
{
    public string Name { get; set; }
    public DataBaseContext.Enums.Role SysName { get; set; }

    private sealed class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, RoleResponse>
    {
        private readonly IRoleRepository _roleRepository;

        public AddRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleResponse> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new DataBaseContext.Entities.Role()
            {
                Name = request.Name,
                SysName = (byte)request.SysName
            };
            var result = await _roleRepository.Add(role);

            return new RoleResponse(result);
        }
    }
    
    public sealed class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
    {
        public AddRoleCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
            RuleFor(c => c.SysName)
                .NotEmpty()
                .NotNull()
                .IsInEnum();
        }
    }
}