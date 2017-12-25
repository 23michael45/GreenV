using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConsoleServer;
using Microsoft.AspNetCore.Mvc;
using NetCoreMvcServer.Models;
using NetCoreMvcServer.Utility;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreMvcServer.Controllers
{
    public class GroundTruthController : FonourControllerBase
    {

        public class ConnectedGroundTruthState : ListContainObjectBase
        {
            public ConnectedGroundTruthState(string id) : base(id)
            {
            }
            public bool mIsStart = false;
            public short mRate = 0;
            public short mGain = 0;

        }

        List<ConnectedGroundTruthState> _ConnectedGroundTruths = new List<ConnectedGroundTruthState>();
        private readonly IGroundTruthAppService _service;
        public GroundTruthController(IGroundTruthAppService service)
        {
            _service = service;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetGroundTruthByDepartment(Guid departmentId, int startPage, int pageSize)
        {
            int rowCount = 0;
            var result = _service.GetGroundTruthByDepartment(departmentId, startPage, pageSize, out rowCount);
      
            JsonResult jr = Json(new
            {
                rowCount = rowCount,
                pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
                rows = result,
            });

            string s = jr.ToString();
            return jr;
        }

        public IActionResult Edit(GroundTruthDto dto, string roles)
        {
            try
            {
                if (dto.Id == Guid.Empty)
                {
                    dto.Id = Guid.NewGuid();
                }
                
                var GroundTruth = _service.InsertOrUpdate(dto);
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


        #region Check Connection

        public IActionResult Sync(Guid id)
        {
            var dto = _service.Get(id);
            return TaskSync(dto.ip).Result;
        }
        Task<JsonResult> TaskSync(string ip)
        {
            return Task.Run(() =>
            {
                bool received = false;
                string receiveip = "";
                MainEntry.SendY(ip, (obj) => {

                    receiveip = (string)obj;
                    received = true;
                    if(!_ConnectedGroundTruths.ContainsStringKey(receiveip))
                    {
                        _ConnectedGroundTruths.AddIfNotExistStringKey(receiveip);
                    }

                });


                int timeout = 5000;
                while(!received)
                {
                    Thread.Sleep(1000);
                    timeout -= 1000;
                    if (received)
                    {
                        return Json(
                            new { ips = _ConnectedGroundTruths});
                    }
                    if(timeout < 0)
                    {
                        break;
                    }
                }

                if (_ConnectedGroundTruths.ContainsStringKey(receiveip))
                {
                    _ConnectedGroundTruths.RemoveIfExistStringKey(receiveip);
                }

                return Json(new { ips = _ConnectedGroundTruths });
            });
            
        }
        async void DoSync(string ip)
        {
            JsonResult jr = await TaskSync(ip);
        }


        public JsonResult SyncAll(Guid departmentId)
        {
            int rowCount = 0;
            var result = _service.GetGroundTruthByDepartment(departmentId, 1, 256, out rowCount);

            return TaskSyncAll(result).Result;
        }

        Task<JsonResult> TaskSyncAll(List<GroundTruthDto> ts)
        {
            return Task.Run(() =>
            {
                _ConnectedGroundTruths.Clear();
                foreach (GroundTruthDto t in ts)
                {
                    string receiveip = "";
                    MainEntry.SendY(t.ip, (obj) =>
                    {

                        receiveip = (string)obj;
                        if (receiveip == "error")
                        {

                        }
                        else
                        {
                            if (!_ConnectedGroundTruths.ContainsStringKey(receiveip))
                            {
                                _ConnectedGroundTruths.AddIfNotExistStringKey(receiveip);
                            }
                        }
                    });
                }


                int timeout = 5000;
                Thread.Sleep(timeout);


                return Json(new { ips = _ConnectedGroundTruths,state = "ok" });
            });
        }
        #endregion

        

    }
}
