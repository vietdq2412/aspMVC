using Microsoft.AspNetCore.Mvc;

namespace aspMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index(int id)
        {
            Console.WriteLine(id);

            return View();
        }

        [Route("admin/details/{adminId}/{id2}/{id3}")]
        public ActionResult Details(int? id2,int? id3,int? adminId)
        {
            Console.WriteLine(adminId);
            return View(adminId);
        }
    }
}
