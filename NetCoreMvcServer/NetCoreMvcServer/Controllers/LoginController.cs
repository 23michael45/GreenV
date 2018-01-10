using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NetCoreMvcServer.Models;
using NetCoreMvcServer.Utility;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using NetCoreMvcServer.Components;
using System.Reflection;
using NetCoreMvcServer;
using System.Globalization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreMvcServer.Controllers
{
    public class LoginController : Controller
    {
        private IUserAppService _userAppService;

        private readonly IStringLocalizer<SharedResource> _SharedLocalizer;

        public LoginController(IUserAppService userAppService, IStringLocalizer<SharedResource> localizer)
        {
            _userAppService = userAppService;
            _SharedLocalizer = localizer;

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            CultureInfo c = System.Threading.Thread.CurrentThread.CurrentUICulture;
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //检查用户信息
                var user = _userAppService.CheckUser(model.UserName, model.Password);
                if (user != null)
                {
                    //记录Session
                    HttpContext.Session.SetString("CurrentUserId", user.Id.ToString());
                    HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(user));
                    //跳转到系统首页
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrorInfo = _SharedLocalizer["Login_UserName_Pwd_NotCorrect"];
                return View();
            }
            foreach (var item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    ViewBag.ErrorInfo = item.Errors[0].ErrorMessage;
                    break;
                }
            }
            return View(model);
        }
    }
}
