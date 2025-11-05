using BookShop_MVC.Application.Contracts.ServiceContracts;
using BookShop_MVC.Application.Services;
using BookShop_MVC.Models.Infrastructure.DateBase;
using Microsoft.AspNetCore.Mvc;
using System;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models;

namespace BookShop_MVC.Controllers
{
    public class BookController(IBookService bookService, ICategoryService categoryService) : Controller
    {
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
