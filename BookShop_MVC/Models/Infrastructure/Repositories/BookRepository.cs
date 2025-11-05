using BookShop_MVC.Application.Contracts.RepositoryContracts;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Entities;
using BookShop_MVC.Models.Infrastructure.DateBase;
using Microsoft.EntityFrameworkCore;

namespace BookShop_MVC.Models.Infrastructure.Repositories
{
    public class BookRepository(AppDbContext _context) : IBookRepository
    {
        public void AddNewBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public List<GetBooksDto> GetBooks()
        {
            return _context.Books.AsNoTracking()
                .OrderByDescending(b => b.CreatedAt)
                .Take(5)
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
