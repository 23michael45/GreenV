using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using UserService;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreMvcServer.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            //Task<string> task = GetUserCallName();
            //return Content(task.Result);

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
