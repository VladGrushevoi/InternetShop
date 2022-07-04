using ShopApi.DataBaseContext.Repositories.Role;
using ShopApi.Features.CQRS.Role.Outputs;

namespace ShopApi.Features.CQRS.Role.Command;

public class UpdateRoleCommand : IRequest<RoleResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DataBaseContext.Enums.Role SysName { get; set; }
    
    private sealed class UpdateRoleCommnadHandler : IRequestHandler<UpdateRoleCommand, RoleResponse>
    {
        private readonly IRoleRepository _roleRepository;

        public UpdateRoleCommnadHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var roleFromReq = new DataBaseContext.Entities.Role()
            {
                Id = request.Id,
                Name = request.Name,
                SysName = (byte)request.SysName
            };
            var result = await _roleRepository.Update(roleFromReq);

            return new RoleResponse(result);
        }
    }
    
    public sealed class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull();

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