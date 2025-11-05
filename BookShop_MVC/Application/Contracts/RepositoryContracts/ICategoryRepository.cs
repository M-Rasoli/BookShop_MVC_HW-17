using BookShop_MVC.Application.DTOs;

namespace BookShop_MVC.Application.Contracts.RepositoryContracts
{
    public interface ICategoryRepository
    {
        List<GetCategoryDto> GetCategory();
        int CreateCategory(CreateCategoryDto categoryDto);
        UpdateCategoryDto GetCategoryById(int categoryId);
        int UpdateCategory(UpdateCategoryDto categoryDto, int categoryId);
        int DeleteCategory(int categoryId);
    }
}
