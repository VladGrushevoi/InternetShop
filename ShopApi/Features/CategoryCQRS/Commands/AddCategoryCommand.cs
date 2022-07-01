using System.Data;
using ShopApi.DataBaseContext.Repositories.Category;

namespace ShopApi.Features.CategoryCQRS.Commands;

public class AddCategoryCommand : IRequest<Category>
{
    public string Name { get; set; }
    
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new()
            {
                Name = request.Name
            };
            var result = _categoryRepository.Add(category);

            return await result;
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