using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NetCoreMvcServer;
//using UserService;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreMvcServer.Controllers
{

    public class HomeController : FonourControllerBase
    {

        public HomeController(IStringLocalizer<SharedResource> localizer) : 
            base(localizer)
        {
        }
        // GET: /<controller>/
        public ActionResult Index()
        {
            return View();
        }

        //async Task<string> GetUserCallName()
        //{
        //    UserClient client = new UserClient();
        //    await client.OpenAsync();
        //    //client.OnSendCheckCBReceived += OnSendCheckCB;

        //    //await client.StartServiceAsync();
        //    return await client.ShowNameAsync("Client Call");
        //}


        //void OnSendCheckCB(object sender,OnSendCheckCBReceivedEventArgs args)
        //{

        //} 
       
    }
}
