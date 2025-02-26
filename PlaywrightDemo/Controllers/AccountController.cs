using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PlaywrightDemo.Models;

namespace PlaywrightDemo.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string fUserId, string fPwd)
        {
            if (string.IsNullOrEmpty(fUserId) || string.IsNullOrEmpty(fPwd))
            {
                ViewBag.Message = "�b���αK�X���ର��";
                return View();
            }
            if(fUserId != "admin@ceec.edu.tw" || fPwd != "123456")
            {
                ViewBag.Message = "�b���αK�X���~";
                return View();
            }
            
            FormsAuthentication.RedirectFromLoginPage(fUserId, true);
            return RedirectToAction("Index", "Default");
        }
    }
}
