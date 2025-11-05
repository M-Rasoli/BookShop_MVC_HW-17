using BookShop_MVC.Application.Contracts.RepositoryContracts;
using BookShop_MVC.Application.Contracts.ServiceContracts;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Infrastructure.Repositories;
using Readify.Domain._common.Entities;

namespace BookShop_MVC.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public Result<bool> CreateCategory(CreateCategoryDto categoryDto)
        {
            if (string.IsNullOrWhiteSpace(categoryDto.Title) ||
                string.IsNullOrWhiteSpace(categoryDto.Description))
            {
                return Result<bool>.Failure(message:"فیلد های اجباری باید کامل شوند.");
            }

            var result = categoryRepository.CreateCategory(categoryDto);
            if (result > 0)
            {
                return Result<bool>.Success(message:"دسته بندی جدید با موفقیت ایجاد شد.");
            }
            else
            {
                return Result<bool>.Failure(message:"مشکلی در ایجاد دسته بندی جدید به وجود آمده است بعدا امتحان کنید .");
            }
        }

        public Result<bool> DeleteCategory(int categoryId)
        {
            var result = categoryRepository.DeleteCategory(categoryId);
            if (result > 0)
            {
                return Result<bool>.Success(message:"دسته بندی با موفقیت حذف شد.");
            }
            else
            {
                return Result<bool>.Failure(message:"مشکلی در حذف نظر سنجی پیش آمده دقایقی دیگر تلاش کنید.");
            }
        }

        public List<GetCategoryDto> GetCategory()
        {
            return categoryRepository.GetCategory();
        }

        public UpdateCategoryDto GetCategoryById(int categoryId)
        {
            return categoryRepository.GetCategoryById(categoryId);
        }

        public Result<bool> UpdateCategory(UpdateCategoryDto categoryDto, int categoryId)
        {
            var result = categoryRepository.UpdateCategory(categoryDto, categoryId);
            if (result > 0)
            {
                return Result<bool>.Success(message:"تغییرات با موفقیت انجام شد.");
            }
            else
            {
                return Result<bool>.Failure(message: "تغییرات با موفقیت انجام نشد.");
            }
        }
    }
}
