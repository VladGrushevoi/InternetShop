using ShopApi.DataBaseContext.Repositories.OrderStatus;
using ShopApi.Features.CQRS.OrderStatus.Outputs;
using ShopApi.Models;

namespace ShopApi.Features.CQRS.OrderStatus.Queries;

public sealed class GetAllOrderStatusQuery : IRequest<DataWithTotal<OrderStatusResponse>>
{
    private sealed class GetAllOrderStatusQueryHandler : IRequestHandler<GetAllOrderStatusQuery, DataWithTotal<OrderStatusResponse>>
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public GetAllOrderStatusQueryHandler(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task<DataWithTotal<OrderStatusResponse>> Handle(GetAllOrderStatusQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderStatusRepository.GetAll();
            var response = result.Select(e => new OrderStatusResponse(e));

            return new DataWithTotal<OrderStatusResponse>(response);
        }
    }
}