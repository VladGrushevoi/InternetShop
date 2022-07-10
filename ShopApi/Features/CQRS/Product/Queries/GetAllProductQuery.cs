using ShopApi.DataBaseContext.Repositories.Product;
using ShopApi.Features.CQRS.Product.Outputs;
using ShopApi.Models;

namespace ShopApi.Features.CQRS.Product.Queries;

public sealed class GetAllProductQuery : IRequest<DataWithTotal<ProductResponse>>
{
    private sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, DataWithTotal<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DataWithTotal<ProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAll();
            var products = result.Select(p => new ProductResponse(p));

            return new DataWithTotal<ProductResponse>(products);
        }
    }
}