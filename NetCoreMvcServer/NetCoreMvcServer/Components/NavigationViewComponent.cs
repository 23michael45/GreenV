using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
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

        IStringLocalizer<SharedResource> _localizer;

        public NavigationViewComponent(IMenuAppService menuAppService, IUserAppService userAppService, IStringLocalizer<SharedResource> localizer)
        {
            _menuAppService = menuAppService;
            _userAppService = userAppService;
            _localizer = localizer;
        }

        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.Session.GetString("CurrentUserId");

            if(userId == null || userId == "")
            {
                RedirectResult rt = new RedirectResult("/Login/Index");
                return View();
            }
            else
            {
                var menus = _menuAppService.GetMenusByUser(Guid.Parse(userId));

                foreach(MenuDto menu in menus)
                {
                    menu.Name = _localizer[menu.Name];
                }

                return View(menus);

            }
        }
    }
}
