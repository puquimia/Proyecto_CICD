using Microsoft.AspNetCore.Mvc;

namespace CICD_WEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
