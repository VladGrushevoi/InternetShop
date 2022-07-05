using ShopApi.DataBaseContext.Repositories.OrderStatus;
using ShopApi.Features.CQRS.OrderStatus.Outputs;

namespace ShopApi.Features.CQRS.OrderStatus.Command;

public sealed class AddOrderStatusCommand : IRequest<OrderStatusResponse>
{
    public string Name { get; set; }
    public DataBaseContext.Enums.OrderStatus SysName { get; set; }
    
    private sealed class AddOrderCommandHandler : IRequestHandler<AddOrderStatusCommand, OrderStatusResponse>
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public AddOrderCommandHandler(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task<OrderStatusResponse> Handle(AddOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var orderStatus = new DataBaseContext.Entities.OrderStatus()
            {
                Name = request.Name,
                SysName = (byte) request.SysName
            };

            var result = await _orderStatusRepository.Add(orderStatus);

            return new OrderStatusResponse(result);
        }
    }
    
    public sealed class AddOrderStatusCommandValidator : AbstractValidator<AddOrderStatusCommand>
    {
        public AddOrderStatusCommandValidator()
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