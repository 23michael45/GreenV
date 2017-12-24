using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConsoleServer;
using Microsoft.AspNetCore.Mvc;
using NetCoreMvcServer.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreMvcServer.Controllers
{
    public class App_GroundTruthDataController : FonourControllerBase
    {
        private readonly ITerminalAppService _service;
        public App_GroundTruthDataController(ITerminalAppService service)
        {
            _service = service;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetTerminalByDepartment(Guid departmentId, int startPage, int pageSize)
        {
            int rowCount = 0;
            var result = _service.GetTerminalByDepartment(departmentId, startPage, pageSize, out rowCount);
      
            JsonResult jr = Json(new
            {
                rowCount = rowCount,
                pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
                rows = result,
            });

            string s = jr.ToString();
            return jr;
        }

        public IActionResult Edit(TerminalDto dto, string roles)
        {
            try
            {
                if (dto.Id == Guid.Empty)
                {
                    dto.Id = Guid.NewGuid();
                }
                
                var Terminal = _service.InsertOrUpdate(dto);
                return Json(new { Result = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Faild", Message = ex.Message });

            }
        }

        public IActionResult DeleteMuti(string ids)
        {
            try
            {
                string[] idArray = ids.Split(',');
                List<Guid> delIds = new List<Guid>();
                foreach (string id in idArray)
                {
                    delIds.Add(Guid.Parse(id));
                }
                _service.DeleteBatch(delIds);
                return Json(new
                {
                    Result = "Success"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Result = "Faild",
                    Message = ex.Message
                });
            }
        }
        public IActionResult Delete(Guid id)
        {
            try
            {
                _service.Delete(id);
                return Json(new
                {
                    Result = "Success"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Result = "Faild",
                    Message = ex.Message
                });
            }
        }
        public IActionResult Get(Guid id)
        {
            var dto = _service.Get(id);
            return Json(dto);
        }

        public IActionResult Check(Guid id)
        {
            var dto = _service.Get(id);
            return TaskCheck(dto.ip).Result;
        }
        Task<JsonResult> TaskCheck(string ip)
        {
            return Task.Run(() =>
            {
                bool received = false;
                string receiveip = "";
                MainEntry.SendT(ip, (obj) => {

                    receiveip = (string)obj;
                    received = true;


                });


                int timeout = 5000;
                while(!received)
                {
                    Thread.Sleep(1000);
                    timeout -= 1000;
                    if (received)
                    {
                        return Json(
                            new { ip = receiveip ,state = "ok"});
                    }
                    if(timeout < 0)
                    {
                        break;
                    }
                }



                return Json(new { state = "failed" });
            });
            
        }
        async void DoCheck(string ip)
        {
            JsonResult jr = await TaskCheck(ip);
        }


        public JsonResult CheckAll(Guid departmentId, int startPage, int pageSize)
        {
            int rowCount = 0;
            var result = _service.GetTerminalByDepartment(departmentId, startPage, pageSize, out rowCount);

            return TaskCheckAll(result).Result;
        }

        Task<JsonResult> TaskCheckAll(List<TerminalDto> ts)
        {
            return Task.Run(() =>
            {
                List<string> connectedip = new List<string>();
                foreach (TerminalDto t in ts)
                {
                    string receiveip = "";
                    MainEntry.SendT(t.ip, (obj) =>
                    {

                        receiveip = (string)obj;

                        if (!connectedip.Contains(receiveip))
                        {
                            connectedip.Add(receiveip);
                        }

                    });
                }


                int timeout = 5000;
                Thread.Sleep(timeout);


                return Json(new { connectedip = "" });
            });
        }
            
        
    }
}
