using BookShop_MVC.Application.Contracts.RepositoryContracts;
using BookShop_MVC.Application.Contracts.ServiceContracts;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models;
using BookShop_MVC.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BookShop_MVC.Controllers
{
    public class AccountController(IUserService userService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(CreateUserDto model)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginUserViewModel model)
        {
            var userLogin = userService.Login(model.UserName, model.Password);
            if (!userLogin.IsSuccess || userLogin.Data == null)
            {
                ViewBag.Error = userLogin.Message;
                return View(model);
            }

            if (userLogin.Data.Role == RoleEnum.Admin)
            {
                return RedirectToAction("Index","Account");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(CreateUserDto model)
        {
            var result = userService.CreateUser(model);
            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View();
            }
            else
            {
                ViewBag.Success = result.Message;
                return View();
                return RedirectToAction("Index", "Home");
            }
           
        }

    }
}
