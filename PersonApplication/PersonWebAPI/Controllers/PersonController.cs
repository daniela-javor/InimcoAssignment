using Microsoft.AspNetCore.Mvc;

namespace PersonWebAPI.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
