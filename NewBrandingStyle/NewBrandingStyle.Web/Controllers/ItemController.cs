using NewBrandingStyle.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace NewBrandingStyle.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        public AddNewItemResponseModel Post(ItemModel item)
        {
            bool _succes = !string.IsNullOrEmpty(item.Description) && !string.IsNullOrEmpty(item.Name);
            string _message = _succes ? "" : "Fields cannot be empty!";

            var response = new AddNewItemResponseModel
            {
                succes = _succes,
                message = _succes ? "" : _message
            };

            return response;
        }
    }
}
