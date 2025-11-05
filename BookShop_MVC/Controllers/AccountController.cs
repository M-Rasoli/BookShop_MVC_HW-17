using BookShop_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop_MVC.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(LoginUserViewModel model)
        {
            if (model != null)
            {

            }
            return View();
        }

    }
}
