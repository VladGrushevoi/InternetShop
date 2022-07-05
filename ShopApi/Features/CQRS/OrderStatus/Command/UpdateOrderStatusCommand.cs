using ShopApi.DataBaseContext.Repositories.OrderStatus;
using ShopApi.Features.CQRS.OrderStatus.Outputs;

namespace ShopApi.Features.CQRS.OrderStatus.Command;

public sealed class UpdateOrderStatusCommand : IRequest<OrderStatusResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DataBaseContext.Enums.OrderStatus SysName { get; set; }
    
    private sealed class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, OrderStatusResponse>
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public UpdateOrderStatusCommandHandler(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task<OrderStatusResponse> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var orderStatusReq = new DataBaseContext.Entities.OrderStatus()
            {
                Id = request.Id,
                Name = request.Name,
                SysName = (byte) request.SysName
            };

            var result = await _orderStatusRepository.Update(orderStatusReq);

            return new OrderStatusResponse(result);
        }
    }
    
    public sealed class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
    {
        public UpdateOrderStatusCommandValidator()
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