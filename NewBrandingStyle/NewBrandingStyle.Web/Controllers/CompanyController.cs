using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewBrandingStyle.Web.Models;

namespace NewBrandingStyle.Web.Controllers
{
    public class CompanyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CompanyModel company)
        {
            var viewModel = new CompanyAddedViewModel
            {
                NumbersOfCharsInName = company.Name.Length,
                NumbersOfCharsInDescription = company.Description.Length,
                IsHidden = company.IsVisible
            };

            return View("CompanyAdded", viewModel);
        }
    }
}