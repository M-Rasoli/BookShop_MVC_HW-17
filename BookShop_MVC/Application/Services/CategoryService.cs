using BookShop_MVC.Application.Contracts.RepositoryContracts;
using BookShop_MVC.Application.Contracts.ServiceContracts;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Infrastructure.Repositories;

namespace BookShop_MVC.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService()
        {
            categoryRepository = new CategoryRepository();
        }
        public List<GetCategoryDto> GetCategory()
        {
            return categoryRepository.GetCategory();
        }
    }
}
