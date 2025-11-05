using BookShop_MVC.Application.Contracts.ServiceContracts;
using BookShop_MVC.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookShop_MVC.Controllers
{
    public class UserController(IUserService userService) : Controller
    {
        public IActionResult Index()
        {
            var users = userService.UsersList();
            return View(users);
        }

        public IActionResult Update(int userId)
        {
            var user = userService.GetUserById(userId);
            return View(user);
        }
        [HttpPost]
        public IActionResult Update(UpdateUserDto model)
        {
            var result = userService.UpdateUser(model, model.Id);
            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
            return RedirectToAction("Index", "User");
        }
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(CreateUserDto model)
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

        public IActionResult DeleteUser(int userId)
        {
            var result = userService.DeleteUser(userId);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.Error = result.Message;
                return View("Index");
            }
        }
    }
}
