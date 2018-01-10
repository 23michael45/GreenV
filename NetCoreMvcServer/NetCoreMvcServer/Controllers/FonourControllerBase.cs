using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCoreMvcServer.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using NetCoreMvcServer;
using System.Globalization;
using System.Threading;

namespace NetCoreMvcServer.Controllers
{
    public abstract class FonourControllerBase : Controller
    {
        public enum ELanguage
        {
            en_US,
            zh_CN,
        }
        protected readonly IStringLocalizer<SharedResource> _localizer;
        public IStringLocalizer<SharedResource> SharedLocalizer
        {
            get
            {
                return _localizer;
            }
        }

        public FonourControllerBase(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {


            byte[] result; 
            filterContext.HttpContext.Session.TryGetValue("CurrentUser",out result);
            if (result == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }

            Response.Cookies.Append("CurrentController",this.GetType().ToString());

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 获取服务端验证的第一条错误信息
        /// </summary>
        /// <returns></returns>
        public string GetModelStateError()
        {
            foreach (var item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    return item.Errors[0].ErrorMessage;
                }
            }
            return "";
        }

      
    }
}
