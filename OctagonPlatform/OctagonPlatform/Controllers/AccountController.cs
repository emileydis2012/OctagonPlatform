using OctagonPlatform.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace OctagonPlatform.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Post: Account
        [HttpPost]
        public ActionResult Login(User user)
        {
            //Implementation Here
            return RedirectToAction("Index", "Dashboard");
        }

        // GET: Account
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}