using System;
using Microsoft.AspNetCore.Mvc;
using NewBrandingStyle.Web.Models;
using NewBrandingStyle.Web.Filters;
using NewBrandingStyle.Web.Databases;
using NewBrandingStyle.Web.Entities;

namespace NewBrandingStyle.Web.Controllers
{
    public class ItemAddController : Controller
    {
        private readonly NewBrandingDBContext _dbContext;

        public ItemAddController(NewBrandingDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [ServiceFilter(typeof(MyCustomFilter))]
        public IActionResult Show(string id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ItemModel item)
        {
            var entity = new ItemEntity
            {
                Name = item.Name,
                Description = item.Description,
                IsVisible = item.IsVisible,
            };

            _dbContext.Items.Add(entity);
            _dbContext.SaveChanges();

            //var viewModel = new AddNewItemConfimation
            //{
            //    Id = 1,
            //    Name = item.Name,
            //};

            //return View("AddConfirmation", viewModel);
            return RedirectToAction("AddConfirmation", new { itemId = 1 });
        }

        [HttpGet]
        public IActionResult AddConfirmation(int itemId)
        {
            return View(itemId);
        }
    }
}