using ShopApi.DataBaseContext.Repositories.OrderStatus;
using ShopApi.Features.CQRS.OrderStatus.Outputs;

namespace ShopApi.Features.CQRS.OrderStatus.Queries;

public sealed class GetByIdOrderStatusQuery : IRequest<OrderStatusResponse>
{
    public Guid Id { get; set; }

    private sealed class GetByIdOrderStatusQueryHandler : IRequestHandler<GetByIdOrderStatusQuery, OrderStatusResponse>
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public GetByIdOrderStatusQueryHandler(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task<OrderStatusResponse> Handle(GetByIdOrderStatusQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderStatusRepository.GetById(request.Id);

            return new OrderStatusResponse(result);
        }
    }
    
    public sealed class GetOrderStatusByIdQueryValidator : AbstractValidator<GetByIdOrderStatusQuery>
    {
        public GetOrderStatusByIdQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}