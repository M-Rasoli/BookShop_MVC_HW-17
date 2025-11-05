using BookShop_MVC.Application.Contracts.ServiceContracts;
using BookShop_MVC.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookShop_MVC.Controllers
{
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        public IActionResult Index()
        {
            var category = categoryService.GetCategory();
            return View(category);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDto model)
        {
            var result = categoryService.CreateCategory(model);
            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }
        }

        public IActionResult Update(int categoryId)
        {
            var category = categoryService.GetCategoryById(categoryId);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryDto model)
        {
            var result = categoryService.UpdateCategory(model, model.Id);
            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }
        }

        public IActionResult Delete(int categoryId)
        {
            var result = categoryService.DeleteCategory(categoryId);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index","Category");
            }
            else
            {
                ViewBag.Error = result.Message;
                return View("Index");
            }
        }
    }
}
