using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreMvcServer.Controllers
{
    public class SharedController : Controller
    {
        // GET: /<controller>/
        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SwitchLanguage()
        {
            string slang = Request.Form["Language"];

            slang = slang.Replace("_", "-");
            Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(slang)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
             );
            
            string CurrentController = "";
            Request.Cookies.TryGetValue("CurrentController", out CurrentController);
            CurrentController = CurrentController.Substring(CurrentController.LastIndexOf('.') + 1);
            CurrentController = CurrentController.Replace("Controller", "");


            return RedirectToAction("Index", CurrentController);
        }

        public IActionResult Navigate(string url)
        {
            string[] strs = url.Split('/');
            string controller = strs[1];
            string action = strs[2];
            Response.Cookies.Append("CurrentController", controller);
            return RedirectToAction(action,controller);
        }
    }
}
