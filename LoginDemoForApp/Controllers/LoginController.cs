using LoginDemoForApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginDemoForApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration configuration;
        LoginDB lgdb;

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
            lgdb = new LoginDB(configuration); 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login lg)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            int res=lgdb.LoginUser(lg);

            if(res>=1)
            {
                //return View();
                HttpContext.Session.SetString("Email", lg.Email);
                HttpContext.Session.SetString("Password", lg.Password);
                return RedirectToAction("HomePage", "User");
            }
            else
            {
                return View();
            }
            
        }
    }
}
