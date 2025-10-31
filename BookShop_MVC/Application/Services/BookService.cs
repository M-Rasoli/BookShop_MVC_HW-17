using BookShop_MVC.Application.Contracts.RepositoryContracts;
using BookShop_MVC.Application.Contracts.ServiceContracts;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Entities;
using BookShop_MVC.Models.Infrastructure.Repositories;

namespace BookShop_MVC.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IFileService fileService;

        public BookService()
        {
            bookRepository = new BookRepository();
            fileService = new FileService();
        }

        public void AddNewBook(AddBookDto book)
        {

            var imgUrl = fileService.Upload(book.ImgUrl!, "Profiles");

            Book newBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                NumberOfPages = book.NumberOfPages,
                CategoryId = book.CategoryId,
                ImgUrl = imgUrl
            };
            bookRepository.AddNewBook(newBook);
        }

        public List<GetBooksDto> GetBooks()
        {
            return bookRepository.GetBooks();
        }
    }
}
