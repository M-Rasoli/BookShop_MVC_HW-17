using BookShop_MVC.Application.Contracts.RepositoryContracts;
using BookShop_MVC.Application.Contracts.ServiceContracts;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Infrastructure.Repositories;

namespace BookShop_MVC.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService()
        {
            bookRepository = new BookRepository();
        }
        public List<GetBooksDto> GetBooks()
        {
            return bookRepository.GetBooks();
        }
    }
}
