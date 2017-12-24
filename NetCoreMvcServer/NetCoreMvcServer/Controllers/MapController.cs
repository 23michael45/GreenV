using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Controllers
{
    public class MapController : FonourControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
