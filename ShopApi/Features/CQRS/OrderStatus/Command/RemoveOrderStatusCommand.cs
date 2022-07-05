using ShopApi.DataBaseContext.Repositories.OrderStatus;
using ShopApi.Features.CQRS.OrderStatus.Outputs;

namespace ShopApi.Features.CQRS.OrderStatus.Command;

public sealed class RemoveOrderStatusCommand : IRequest<OrderStatusResponse>
{
    public Guid Id { get; set; }
    
    private sealed class RemoveOrderStatusCommandHandler : IRequestHandler<RemoveOrderStatusCommand, OrderStatusResponse>
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public RemoveOrderStatusCommandHandler(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task<OrderStatusResponse> Handle(RemoveOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var result = await _orderStatusRepository.Remove(request.Id);

            return new OrderStatusResponse(result);
        }
    }
    
    public sealed class RemoverOrderStatusCommandValidator : AbstractValidator<RemoveOrderStatusCommand>
    {
        public RemoverOrderStatusCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}