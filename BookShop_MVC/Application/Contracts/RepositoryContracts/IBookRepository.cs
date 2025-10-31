using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Entities;

namespace BookShop_MVC.Application.Contracts.RepositoryContracts
{
    public interface IBookRepository
    {
        List<GetBooksDto> GetBooks();
        void AddNewBook(Book book);
    }
}
