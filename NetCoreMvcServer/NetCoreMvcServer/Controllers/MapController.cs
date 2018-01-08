using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Controllers
{
    public class MapController : FonourControllerBase
    {
        public MapController( IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
