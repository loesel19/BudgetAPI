using BudgetAPI.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAPI.API.Controllers
{
    public class BaseController : Controller
    {
        public static IService _service;
        public BaseController(IService service)
        {
            _service = service;
        }
    }
}
