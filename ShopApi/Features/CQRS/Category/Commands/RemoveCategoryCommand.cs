using ShopApi.DataBaseContext.Repositories.Category;
using ShopApi.Features.CQRS.Category.Outputs;

namespace ShopApi.Features.CQRS.Category.Commands;

public sealed class RemoveCategoryCommand : IRequest<CategoryResponse>
{
    public Guid Id { get; set; }
    
    private sealed class RemoveCategoryHandler : IRequestHandler<RemoveCategoryCommand, CategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public RemoveCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponse> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.Remove(request.Id);

            return new CategoryResponse(result);
        }
    }

    private sealed class RemoveCategoryCommandValidator : AbstractValidator<RemoveCategoryCommand>
    {
        public RemoveCategoryCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}