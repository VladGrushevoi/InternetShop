using ShopApi.Features.CQRS.User.Outputs;
using ShopApi.Models;

namespace ShopApi.Features.CQRS.User.Queries;

public sealed class GetAllUserQuery : IRequest<DataWithTotal<UserResponse>>
{
    private sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, DataWithTotal<UserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DataWithTotal<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAll();
            var responses = result.Select(c => new UserResponse(c));
            return new DataWithTotal<UserResponse>(responses);
        }
    }
}