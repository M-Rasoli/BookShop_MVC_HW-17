using BookShop_MVC.Application.DTOs;
using Readify.Domain._common.Entities;

namespace BookShop_MVC.Application.Contracts.ServiceContracts
{
    public interface ICategoryService
    {
        List<GetCategoryDto> GetCategory();
        Result<bool> CreateCategory(CreateCategoryDto categoryDto);
        UpdateCategoryDto GetCategoryById(int categoryId);
        Result<bool> UpdateCategory(UpdateCategoryDto categoryDto , int categoryId);
        Result<bool> DeleteCategory(int categoryId);
    }

}
