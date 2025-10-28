using BookShop_MVC.Application.DTOs;

namespace BookShop_MVC.Application.Contracts.RepositoryContracts
{
    public interface ICategoryRepository
    {
        List<GetCategoryDto> GetCategory();
    }
}
