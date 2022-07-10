using ShopApi.DataBaseContext.Repositories.Product;
using ShopApi.Features.CQRS.Product.Outputs;

namespace ShopApi.Features.CQRS.Product.Command;

public sealed class RemoveProductCommand : IRequest<ProductResponse>
{
    public Guid Id { get; set; }
    
    private sealed class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public RemoveProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.Remove(request.Id);
            return new ProductResponse(result);
        }
    }
    
    public sealed class RemoveProductCommandValidator : AbstractValidator<RemoveProductCommand>
    {
        public RemoveProductCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}