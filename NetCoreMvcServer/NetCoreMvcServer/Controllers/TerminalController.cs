﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConsoleServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NetCoreMvcServer;
using NetCoreMvcServer.Models;
using NetCoreMvcServer.Utility;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreMvcServer.Controllers
{
    public class TerminalController : FonourControllerBase
    {

        public class ConnectedTerminalState : ListContainObjectBase
        {
            public ConnectedTerminalState(string id) :base(id)
            {
                StartTimer();
            }
            public bool mIsStart = false;
            public ushort mRate = 0;
            public ushort mGain = 0;

            System.Timers.Timer _Timer;
            void StartTimer()
            {
                _Timer = new System.Timers.Timer();

                _Timer.Interval = 30000;
                _Timer.Elapsed -= HandleTimer;
                _Timer.Elapsed += HandleTimer;

                _Timer.AutoReset = false;
                _Timer.Start();
            }
            public void ResetTimer()
            {
                if(_Timer != null)
                {
                    _Timer.Stop();
                    _Timer.Close();
                }

                StartTimer();
                

            }

            void HandleTimer(object sender, System.Timers.ElapsedEventArgs e)
            {
                if (_Timer != null)
                {
                    _Timer.Stop();
                }
                TerminalController._ConnectedTerminals.RemoveIfExistStringKey(mId);
            }

        }

        public static List<ConnectedTerminalState> _ConnectedTerminals = new List<ConnectedTerminalState>();

        private readonly ITerminalAppService _service;
        public TerminalController(ITerminalAppService service, IStringLocalizer<SharedResource> localizer) : base(localizer)
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


        #region Check Connection

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
                    if(!_ConnectedTerminals.ContainsStringKey(receiveip))
                    {
                        _ConnectedTerminals.AddIfNotExistStringKey(receiveip);
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
                            new { ips = _ConnectedTerminals});
                    }
                    if(timeout < 0)
                    {
                        break;
                    }
                }

                if (_ConnectedTerminals.ContainsStringKey(receiveip))
                {
                    _ConnectedTerminals.RemoveIfExistStringKey(receiveip);
                }

                return Json(new { ips = _ConnectedTerminals });
            });
            
        }
        async void DoCheck(string ip)
        {
            JsonResult jr = await TaskCheck(ip);
        }


        public JsonResult CheckAll(Guid departmentId)
        {
            int rowCount = 0;
            var result = _service.GetTerminalByDepartment(departmentId, 1, 256, out rowCount);

            return TaskCheckAll(result).Result;
        }

        Task<JsonResult> TaskCheckAll(List<TerminalDto> ts)
        {
            return Task.Run(() =>
            {
                _ConnectedTerminals.Clear();
                foreach (TerminalDto t in ts)
                {
                    string receiveip = "";
                    MainEntry.SendT(t.ip, (obj) =>
                    {

                        receiveip = (string)obj;
                        if (receiveip == "error")
                        {

                        }
                        else
                        {
                            if (!_ConnectedTerminals.ContainsStringKey(receiveip))
                            {
                                _ConnectedTerminals.AddIfNotExistStringKey(receiveip);
                            }
                        }
                    });
                }


                int timeout = 5000;
                Thread.Sleep(timeout);


                return Json(new { ips = _ConnectedTerminals,state = "ok" });
            });
        }

        public IActionResult GetOnLineTerminals()
        {
            if(_ConnectedTerminals == null || _ConnectedTerminals.Count <= 0)
            {
                return Json(new { });
            }
            else
            {
                return Json(new { ips = _ConnectedTerminals, state = "ok" });

            }


        }
        #endregion

        #region Start Stop Terminal

        public JsonResult StartTerminal(string ip)
        {
            return TaskStartStop(ip, true).Result;
        }
        public JsonResult StopTerminal(string ip)
        {
            return TaskStartStop(ip,false).Result;
        }
        public JsonResult UpdateSetup(string ip,ushort rate,ushort gain)
        {
            return TaskSetup(ip,rate,gain).Result;

        }
        public JsonResult StartAll(Guid departmentId)
        {
            int rowCount = 0;
            var result = _service.GetTerminalByDepartment(departmentId, 1, 256, out rowCount);

            return TaskStartStopAll(result,true).Result;
        }
        public JsonResult StopAll(Guid departmentId)
        {
            int rowCount = 0;
            var result = _service.GetTerminalByDepartment(departmentId, 1, 256, out rowCount);

            return TaskStartStopAll(result,false).Result;
        }
        public JsonResult UpdateSetupAll(Guid departmentId,ushort rate,ushort gain)
        {
            int rowCount = 0;
            var result = _service.GetTerminalByDepartment(departmentId, 1, 256, out rowCount);

            return TaskSetupAll(result,rate,gain).Result;
        }


        Task<JsonResult> TaskStartStop(string ip,bool start)
        {
            return Task.Run(() =>
            {
                bool received = false;
                string receiveip = "";
                MainEntry.SendS(ip,start, (obj) =>
                {
                    receiveip = (string)obj; if (receiveip == "error")
                    {

                    }
                    else
                    {
                        received = true;

                        ConnectedTerminalState t = _ConnectedTerminals.GetStringKey(receiveip);
                        if (t != null)
                        {
                            t.mIsStart = start;
                        }
                    }
                });


                int timeout = 5000;
                while (!received)
                {
                    Thread.Sleep(1000);
                    timeout -= 1000;
                    if (received)
                    {
                        return Json(
                            new { ips = _ConnectedTerminals });
                    }
                    if (timeout < 0)
                    {
                        break;
                    }
                }
                
                return Json(new { ips = _ConnectedTerminals });
            });

        }

        Task<JsonResult> TaskSetup(string ip,ushort rate,ushort gain)
        {
            return Task.Run(() =>
            {
                bool received = false;
                string receiveip = "";
                MainEntry.SendC(ip, rate,gain, (obj) =>
                {
                    receiveip = (string)obj;

                    if(receiveip == "error")
                    {

                    }
                    else
                    {

                        received = true;
                        ConnectedTerminalState t = _ConnectedTerminals.GetStringKey(receiveip);
                        if (t != null)
                        {
                            t.mRate = rate;
                            t.mGain = gain;
                        }

                    }
                });


                int timeout = 5000;
                while (!received)
                {
                    Thread.Sleep(1000);
                    timeout -= 1000;
                    if (received)
                    {
                        return Json(
                            new { ips = _ConnectedTerminals });
                    }
                    if (timeout < 0)
                    {
                        break;
                    }
                }

                return Json(new { ips = _ConnectedTerminals });
            });

        }


        Task<JsonResult> TaskStartStopAll(List<TerminalDto> ts,bool start)
        {
            return Task.Run(() =>
            {
                _ConnectedTerminals.Clear();
                foreach (TerminalDto t in ts)
                {
                    string receiveip = "";
                    MainEntry.SendS(t.ip,start,(obj) =>
                    {

                        receiveip = (string)obj;
                        if (receiveip == "error")
                        {

                        }
                        else
                        {
                            if (!_ConnectedTerminals.ContainsStringKey(receiveip))
                            {
                                _ConnectedTerminals.AddIfNotExistStringKey(receiveip);
                            }
                        }
                    });
                }


                int timeout = 5000;
                Thread.Sleep(timeout);


                return Json(new { ips = _ConnectedTerminals, state = "ok" });
            });
        }
        Task<JsonResult> TaskSetupAll(List<TerminalDto> ts, ushort rate,ushort gain)
        {
            ConnectedTerminalState cts;
            return Task.Run(() =>
            {
                _ConnectedTerminals.Clear();
                foreach (TerminalDto t in ts)
                {
                    string receiveip = "";
                    MainEntry.SendC(t.ip, rate,gain, (obj) =>
                    {

                        receiveip = (string)obj;
                        if (receiveip == "error")
                        {

                        }
                        else
                        {
                            if (!_ConnectedTerminals.ContainsStringKey(receiveip))
                            {
                                _ConnectedTerminals.AddIfNotExistStringKey(receiveip);

                                cts = _ConnectedTerminals.GetStringKey(receiveip);
                                if (cts != null)
                                {
                                    cts.mRate = rate;
                                    cts.mGain = gain;
                                }

                            }
                        }
                    });
                }


                int timeout = 5000;
                Thread.Sleep(timeout);


                return Json(new { ips = _ConnectedTerminals, state = "ok" });
            });
        }
        #endregion

    }
}
