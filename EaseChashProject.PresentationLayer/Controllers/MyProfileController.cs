using Microsoft.AspNetCore.Mvc;

namespace EaseChashProject.PresentationLayer.Controllers
{
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
