using BookShop_MVC.Application.Contracts.RepositoryContracts;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Infrastructure.DateBase;
using Microsoft.EntityFrameworkCore;

namespace BookShop_MVC.Models.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository()
        {
            _context = new AppDbContext();
        }
        public List<GetBooksDto> GetBooks()
        {
            return _context.Books.AsNoTracking()
                .OrderByDescending(b => b.CreatedAt)
                .Select(x => new GetBooksDto()
                {
                    Title = x.Title,
                    Author = x.Author,
                    Price = x.Price,
                    NumberOfPages = x.NumberOfPages,
                    ImgUrl = x.ImgUrl
                }).ToList();
        }
    }
}
