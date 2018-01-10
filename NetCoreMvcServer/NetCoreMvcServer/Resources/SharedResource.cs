using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreMvcServer
{
    public class SharedResource
    {
        public static IStringLocalizer<SharedResource> _Localizer;
        public static IStringLocalizer<SharedResource> GetLocalizer()
        {
            return _Localizer;
        }

        public static string GetCurrentLanguge()
        {
           string lang = Thread.CurrentThread.CurrentUICulture.Name;
            return lang;
        }

    }
}

