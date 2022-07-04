using ShopApi.DataBaseContext.Repositories.Category;
using ShopApi.Features.CQRS.Category.Outputs;

namespace ShopApi.Features.CQRS.Category.Commands;

public class AddCategoryCommand : IRequest<CategoryResponse>
{
    public string Name { get; set; }
    
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, CategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponse> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            DataBaseContext.Entities.Category category = new()
            {
                Name = request.Name
            };
            var result = _categoryRepository.Add(category);
            var response = new CategoryResponse(await result);
            
            return response;
        }
        
        public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
        {
            public AddCategoryCommandValidator()
            {
                RuleFor(c => c.Name)
                    .NotEmpty()
                    .MaximumLength(50);
            }
        }
    }
}