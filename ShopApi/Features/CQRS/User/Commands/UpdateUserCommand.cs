using ShopApi.DataBaseContext.Repositories.Role;
using ShopApi.Features.CQRS.User.Outputs;

namespace ShopApi.Features.CQRS.User.Commands;

public sealed class UpdateUserCommand : IRequest<UserResponse>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public DataBaseContext.Enums.Role Role { get; set; }
    
    private sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetRoleBySysName((byte)request.Role);
            var updateUser = new DataBaseContext.Entities.User()
            {
                Id = request.Id,
                Login = request.Login,
                Password = request.Password,
                Phone = request.Phone,
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                Role = role
            };

            var result = await _userRepository.Update(updateUser);

            return new UserResponse(result);
        }
    }
    
    public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .MinimumLength(2);
            RuleFor(c => c.SecondName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .MinimumLength(2);
            RuleFor(c => c.Login)
                .NotEmpty()
                .NotNull()
                .MaximumLength(15)
                .MinimumLength(6);
            RuleFor(c => c.Password)
                .NotEmpty()
                .NotNull()
                .MaximumLength(25)
                .MinimumLength(6);
            RuleFor(c => c.Phone)
                .NotEmpty()
                .NotNull()
                .MaximumLength(10)
                .MinimumLength(10);
            RuleFor(c => c.Role)
                .NotNull()
                .NotEmpty()
                .IsInEnum();

        }
    }
}