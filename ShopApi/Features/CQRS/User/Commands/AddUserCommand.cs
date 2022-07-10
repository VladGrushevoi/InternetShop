using ShopApi.DataBaseContext.Repositories.Role;
using ShopApi.Features.CQRS.User.Outputs;

namespace ShopApi.Features.CQRS.User.Commands;

public sealed class AddUserCommand : IRequest<UserResponse>
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public DataBaseContext.Enums.Role Role { get; set; }
    
    private sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AddUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetRoleBySysName((byte) request.Role);
            var user = new DataBaseContext.Entities.User()
            {
                Login = request.Login,
                Password = request.Password,
                Phone = request.Phone,
                Role = role,
                FirstName = request.FirstName,
                SecondName = request.SecondName
            };

            var result = await _userRepository.Add(user);

            return new UserResponse(result);
        }
    }
    
    public sealed class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
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