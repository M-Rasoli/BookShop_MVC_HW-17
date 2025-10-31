using BookShop_MVC.Application.Contracts.ServiceContracts;
using BookShop_MVC.Application.Services;
using BookShop_MVC.Models.Infrastructure.DateBase;
using Microsoft.AspNetCore.Mvc;
using System;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models;

namespace BookShop_MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;

        public BookController()
        {
            bookService = new BookService();
            categoryService = new CategoryService();
        }

        public IActionResult Add()
        {
            AddNewBookModel book = new AddNewBookModel()
            {
                Category = categoryService.GetCategory(),
            };
            return View("AddBook", book);
        }
        [HttpPost]
        public IActionResult Add(AddBookDto model)
        {
            bookService.AddNewBook(model);
            return RedirectToAction("Index","Home");
        }

    }
}
