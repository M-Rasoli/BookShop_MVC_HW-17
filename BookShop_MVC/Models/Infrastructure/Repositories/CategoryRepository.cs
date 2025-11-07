using BookShop_MVC.Application.Contracts.RepositoryContracts;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Entities;
using BookShop_MVC.Models.Infrastructure.DateBase;
using Microsoft.EntityFrameworkCore;

namespace BookShop_MVC.Models.Infrastructure.Repositories
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public int CreateCategory(CreateCategoryDto categoryDto)
        {
            Category category = new Category()
            {
                Title = categoryDto.Title,
                Description = categoryDto.Description
            };
            _context.Categories.Add(category);
            return _context.SaveChanges();
        }

        public int DeleteCategory(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
            _context.Categories.Remove(category);
            return _context.SaveChanges();
        }

        public List<GetCategoryDto> GetCategory()
        {
            return _context.Categories
                .AsNoTracking()
                .Select(x => new GetCategoryDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                }).ToList();
        }

        public UpdateCategoryDto GetCategoryById(int categoryId)
        {
            return _context.Categories.Where(c => c.Id == categoryId)
                .Select(x => new UpdateCategoryDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                }).FirstOrDefault();
        }

        public int UpdateCategory(UpdateCategoryDto categoryDto, int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category is not null)
            {
                category.Title = categoryDto.Title;
                category.Description = categoryDto.Description;
            }

            return _context.SaveChanges();
        }
    }
}
