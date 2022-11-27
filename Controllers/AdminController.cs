using Microsoft.AspNetCore.Mvc;

namespace ApInitial.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
