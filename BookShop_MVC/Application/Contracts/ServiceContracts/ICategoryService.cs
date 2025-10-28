using BookShop_MVC.Application.DTOs;

namespace BookShop_MVC.Application.Contracts.ServiceContracts
{
    public interface ICategoryService
    {
        List<GetCategoryDto> GetCategory();
    }
}
