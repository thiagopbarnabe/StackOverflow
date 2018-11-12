using Microsoft.AspNetCore.Mvc;

namespace StackOverflow.Web.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
