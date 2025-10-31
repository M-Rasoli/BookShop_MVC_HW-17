using BookShop_MVC.Application.Contracts.RepositoryContracts;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Infrastructure.DateBase;
using Microsoft.EntityFrameworkCore;

namespace BookShop_MVC.Models.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository()
        {
            _context = new AppDbContext();
        }
        public List<GetCategoryDto> GetCategory()
        {
            return _context.Categories.AsNoTracking()
                .Select(x => new GetCategoryDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                }).ToList();
        }
    }
}
