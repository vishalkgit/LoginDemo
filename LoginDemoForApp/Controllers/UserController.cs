using LoginDemoForApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginDemoForApp.Controllers
{
    public class UserController : Controller
    {
        LoginDB ldb;
        UserController us;

        public UserController(IConfiguration configuration)
        {
            this.Configuration = configuration;
            ldb = new LoginDB(configuration);
        }

        public IConfiguration Configuration { get; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HomePage()
        {

            var res = HttpContext.Session.GetString("Email");
            ViewBag.Email = res;
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
