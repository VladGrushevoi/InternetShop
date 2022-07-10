using ShopApi.Features.CQRS.User.Outputs;

namespace ShopApi.Features.CQRS.User.Commands;

public sealed class RemoveUserCommand : IRequest<UserResponse>
{
    public Guid Id { get; set; }
    
    private sealed class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.Remove(request.Id);

            return new UserResponse(result);
        }
    }
    
    public sealed class RemoveUserCommandValidator : AbstractValidator<RemoveUserCommand>
    {
        public RemoveUserCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}