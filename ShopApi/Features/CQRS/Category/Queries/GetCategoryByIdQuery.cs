using ShopApi.DataBaseContext.Repositories.Category;
using ShopApi.Features.CQRS.Category.Outputs;

namespace ShopApi.Features.CQRS.Category.Queries;

public sealed class GetCategoryByIdQuery : IRequest<CategoryResponse>
{
    public Guid Id { get; set; }
    
    private sealed class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdHandler(ICategoryRepository repo)
        {
            _categoryRepository = repo;
        }
        public async Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetById(request.Id);

            return new CategoryResponse(result);
        }
    }
    
    public sealed class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}