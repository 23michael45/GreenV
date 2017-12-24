using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreMvcServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Components
{
    [ViewComponent(Name = "Navigation")]
    public class NavigationViewComponent : ViewComponent
    {
        private readonly IMenuAppService _menuAppService;
        private readonly IUserAppService _userAppService;
        public NavigationViewComponent(IMenuAppService menuAppService, IUserAppService userAppService)
        {
            _menuAppService = menuAppService;
            _userAppService = userAppService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.Session.GetString("CurrentUserId");

            if(userId == null || userId == "")
            {
                //跳转到系统首页
                return Content("登录超时，请重新登录！");
            }
            else
            {
                var menus = _menuAppService.GetMenusByUser(Guid.Parse(userId));
                return View(menus);

            }
        }
    }
}
