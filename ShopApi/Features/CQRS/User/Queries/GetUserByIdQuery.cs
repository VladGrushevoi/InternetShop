using ShopApi.Features.CQRS.User.Outputs;

namespace ShopApi.Features.CQRS.User.Queries;

public sealed class GetUserByIdQuery : IRequest<UserResponse>
{
    public Guid Id { get; set; }
    
    private sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetById(request.Id);

            return new UserResponse(result);
        }
    }
    
    public sealed class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}