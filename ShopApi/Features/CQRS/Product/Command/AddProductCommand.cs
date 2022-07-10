using System.Data;
using ShopApi.DataBaseContext.Repositories.Category;
using ShopApi.DataBaseContext.Repositories.Product;
using ShopApi.Features.CQRS.Product.Outputs;

namespace ShopApi.Features.CQRS.Product.Command;

public sealed class AddProductCommand : IRequest<ProductResponse>
{
    public Guid CategoryId { get; set; }
    public string Brand { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public decimal Price { get; set; }
    public string? AdditionalCharacteristic { get; set; }
    public int Count { get; set; }
    
    private sealed class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AddProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new DataBaseContext.Entities.Product()
            {
                Category = await _categoryRepository.GetById(request.CategoryId),
                Count = request.Count,
                ProductDescription = new ProductDescription()
                {
                    Brand = request.Brand,
                    Model = request.Model,
                    Name = request.Name,
                    Price = request.Price,
                    Year = request.Year,
                    AdditionalCharacteristic = request.AdditionalCharacteristic
                },
                DateCreated = new DateOnly(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day)
            };

            var result = await _productRepository.Add(product);

            return new ProductResponse(result);
        }
        
    }
    
    public sealed class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(c => c.CategoryId)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Brand)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
            RuleFor(c => c.Model)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
            RuleFor(c => c.Year)
                .NotEmpty()
                .NotNull()
                .MaximumLength(4)
                .MaximumLength(4);
            RuleFor(c => c.Price)
                .NotEmpty()
                .NotNull()
                .Must(p => p > 0);
            RuleFor(c => c.Count)
                .NotEmpty()
                .NotNull()
                .Must(p => p > 0);

        }
    }
}