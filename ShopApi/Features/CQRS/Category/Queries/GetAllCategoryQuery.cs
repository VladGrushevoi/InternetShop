using ShopApi.DataBaseContext.Repositories.Category;
using ShopApi.Features.CQRS.Category.Outputs;
using ShopApi.Models;

namespace ShopApi.Features.CQRS.Category.Queries;

public class GetAllCategoryQuery : IRequest<DataWithTotal<CategoryResponse>>
{
    private class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, DataWithTotal<CategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<DataWithTotal<CategoryResponse>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAll();
            var categories = result.Select(c => new CategoryResponse() { Id = c.Id, Name = c.Name });

            return new DataWithTotal<CategoryResponse>(categories);
        }
    }
}