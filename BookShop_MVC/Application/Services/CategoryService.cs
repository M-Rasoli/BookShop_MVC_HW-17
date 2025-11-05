using BookShop_MVC.Application.Contracts.RepositoryContracts;
using BookShop_MVC.Application.Contracts.ServiceContracts;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Infrastructure.Repositories;

namespace BookShop_MVC.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public List<GetCategoryDto> GetCategory()
        {
            return categoryRepository.GetCategory();
        }
    }
}
