using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlaywrightDemo.Models;

namespace PlaywrightDemo.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        // GET: Default
        
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Index(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                return Content($"使用者：{userInfo.Name}資料新增成功");
            }
            else
            {
                return View(userInfo);
            }
        }
    }
}