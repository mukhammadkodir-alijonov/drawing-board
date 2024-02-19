using Microsoft.AspNetCore.Mvc;

namespace DrawingBoard.Controllers
{
    public class DrawingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
