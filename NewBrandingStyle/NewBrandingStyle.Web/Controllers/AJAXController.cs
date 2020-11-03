using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewBrandingStyle.Web.Models;

namespace NewBrandingStyle.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AJAXController : ControllerBase
    {
        public CompanyAddedViewModel Post(CompanyAddedViewModel model)
        {
            return model;
        }
    }
}
