using ShopApi.DataBaseContext.Repositories.Category;
using ShopApi.Features.CQRS.Category.Outputs;

namespace ShopApi.Features.CQRS.Category.Commands;

public class UpdateCategoryCommand : IRequest<CategoryResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    private class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = new DataBaseContext.Entities.Category()
            {
                Id = request.Id,
                Name = request.Name
            };

            var result = _categoryRepository.Update(newCategory);
            var response = new CategoryResponse(await result);
            
            return response;
        }
    }
    
    private class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Name)
                .MaximumLength(50)
                .NotEmpty()
                .NotNull();
        }
    }
}