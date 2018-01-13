using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using NetCoreMvcServer;
using NetCoreMvcServer.Models;

namespace NetCoreMvcServer.Controllers
{
    public class App_SensorDataController : FonourControllerBase
    {
        private readonly GVContext _context;
        private readonly IApp_SensorDataRepository _repository;

        static  Dictionary<string, byte[]> _TempDataDic = new Dictionary<string, byte[]>();

        static float _Progress = 0;

        public App_SensorDataController(GVContext context,IApp_SensorDataRepository repository, IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
            _context = context;
            _repository = repository;
        }

        // GET: App_SensorData
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: App_SensorData/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var app_SensorData = await _context.App_SensorData
                .SingleOrDefaultAsync(m => m.Id == id);
            if (app_SensorData == null)
            {
                return NotFound();
            }

            return View(app_SensorData);
        }

        // GET: App_SensorData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: App_SensorData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,device,timestamps,timestampms,sendsorvalue")] App_SensorData app_SensorData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(app_SensorData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(app_SensorData);
        }

        // GET: App_SensorData/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var app_SensorData = await _context.App_SensorData.SingleOrDefaultAsync(m => m.Id == id);
            if (app_SensorData == null)
            {
                return NotFound();
            }
            return View(app_SensorData);
        }

        // POST: App_SensorData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,device,timestamps,timestampms,sendsorvalue")] App_SensorData app_SensorData)
        {
            if (id != app_SensorData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(app_SensorData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!App_SensorDataExists(app_SensorData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(app_SensorData);
        }

 

        // POST: App_SensorData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var app_SensorData = await _context.App_SensorData.SingleOrDefaultAsync(m => m.Id == id);
            _context.App_SensorData.Remove(app_SensorData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool App_SensorDataExists(Guid id)
        {
            return _context.App_SensorData.Any(e => e.Id == id);
        }
        
        public IActionResult GetDataByDepartment( int startPage, int pageSize, Guid departmentId)
        {
            return Content(departmentId.ToString());
        }
        public IActionResult Query(int startPage, int pageSize,string dt,string ip)
        {

            IQueryable<App_SensorData> rt = DoQuery(dt, ip);


            List<App_SensorDataDto> rtd = new List<App_SensorDataDto>();
            foreach (App_SensorData asd in rt)
            {
                Guid id = asd.Id;
                string device = asd.device;
                int timestamps = asd.timestamps;
                int timestampms = asd.timestampms;
                int rate = asd.rate;
                int gain = asd.gain;
                DateTime createtime = asd.createtime;



                byte[] data = new byte[1200];
                long len = asd.sensorvalue.Length;
                MemoryStream ms = new MemoryStream(asd.sensorvalue);
                BinaryReader reader = new BinaryReader(ms);



                for (int i = 0; i < len / 2; i++)
                {
                    UInt16 d = reader.ReadUInt16();

                    App_SensorDataDto dto = new App_SensorDataDto();
                    dto.device = asd.device;
                    dto.timestamps = asd.timestamps;
                    dto. timestampms = asd.timestampms;
                    dto. rate = asd.rate;
                    dto. gain = asd.gain;
                    dto. createtime = asd.createtime;
                    dto.sensorvalue = d;

                    rtd.Add(dto);
                }
            }


            List<App_SensorDataDto> pagert = new List<App_SensorDataDto>();

            //rt = rt.Skip((startPage - 1) * pageSize).Take(pageSize);

            for(int i = (startPage - 1) * pageSize; i< (startPage - 1) * pageSize + pageSize; i++)
            {
                pagert.Add(rtd[i]);
            }



            int totalCount = rtd.Count;
            return Json(new
            {
                rowCount = totalCount,
                pageCount = Math.Ceiling(Convert.ToDecimal(totalCount) / pageSize),
                rows = pagert
            });




        }


        IQueryable<App_SensorData> DoQuery(string ip,DateTime startdt,DateTime enddt)
        {
            IQueryable<App_SensorData> rt = null;
            if (ip == null || ip == "" || ip == "undefined")
            {
                rt = _context.App_SensorData.Where(item => (item.createtime > startdt && item.createtime < enddt)).OrderBy(it => it.createtime);

            }
            else
            {
                rt = _context.App_SensorData.Where(item => (item.device == ip) && (item.createtime > startdt && item.createtime < enddt)).OrderBy(it => it.createtime);

            }
            return rt;
        }

        IQueryable<App_SensorData> DoQuery(string dt, string ip)
        {
            //12/25/2017 4:00 AM - 12/25/2017 11:59 PM
            string[] times = dt.Split('-');

            DateTime starttime = DateTime.Parse(times[0]);
            DateTime endtime = DateTime.Parse(times[1]);

            return DoQuery(ip, starttime, endtime);
        }


        public IActionResult QueryAndExport(string dt, string ip)
        {
            _Progress = 0;
            IQueryable<App_SensorData> rt = DoQuery(dt, ip);
            SaveSensor(rt.OrderBy(it => it.createtime),ref _Progress);


            FileStream fs = new FileStream("sensor.txt", FileMode.OpenOrCreate);
            byte[] content = ReadFile(fs);
            fs.Close();

            

            string msg = "";
            bool isempty = false;
            if(rt.Count<App_SensorData>() == 0)
            {
                isempty = true;
                msg = SharedLocalizer["SensorData_Null_Result"];
            }
            else
            {
                isempty = false;
                msg = string.Format(SharedLocalizer["SensorData_Query_Result"], rt.Count<App_SensorData>());


            }

            return Json(new
            {
                IsEmpty = isempty,
                Msg = msg,
                fileName = "sensor.txt",
            });
        }


        public IActionResult QueryProgress()
        {

            return Json(new
            {
                PercentComplete = _Progress

            });
        }



        public IActionResult Delete(Guid id)
        {
            try
            {
                _repository.Delete(id);
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

        public IActionResult DownloadFile(string dt, string ip)
        {
            return Json(new 
            {
                fileName = "sensor.txt" ,
            });
        }

        byte[] SaveSensor(IQueryable<App_SensorData> list,ref float progress)
        {
            if(System.IO.File.Exists("sensor.txt") == true)
            {
                System.IO.File.Delete("sensor.txt");
            }
            
            if(list == null)
            {
                return null;
            }

            FileStream fs = new FileStream("sensor.txt", FileMode.OpenOrCreate);
            var file = new System.IO.StreamWriter(fs);

            int totalCount = list.Count<App_SensorData>();
            int curCount = 0;
            foreach (App_SensorData asd in list)
            {


                Guid id = asd.Id;
                string device = asd.device;
                int timestamps = asd.timestamps;
                int timestampms = asd.timestampms;
                int rate = asd.rate;
                int gain = asd.gain;
                DateTime createtime = asd.createtime;



                byte[] data = new byte[1200];
                long len = asd.sensorvalue.Length;
                MemoryStream ms = new MemoryStream(asd.sensorvalue);
                BinaryReader reader = new BinaryReader(ms);



                string s = string.Format("id:{0} device:{1} createtime:{2} timestamp:{3} : {4}  rate: {5}  gain:{6} data: ", id, device, createtime,timestamps, timestampms, rate, gain);
                for (int i = 0; i < len / 2; i++)
                {
                    UInt16 d = reader.ReadUInt16();
                    s += " " + d.ToString();
                }
                file.WriteLine(s);


                curCount++;

                progress = (float)curCount * 100 / totalCount;
                
            }

            file.Flush();


            fs.Close();

            return null;
        }
        [HttpGet]
        public virtual ActionResult Download(string fileName)
        {
            if(System.IO.File.Exists("sensor.txt"))
            {

                FileStream fs = new FileStream("sensor.txt", FileMode.OpenOrCreate);
                byte[] content = ReadFile(fs);
                fs.Close();


                return File(content, "text/plain", fileName);
            }
            else
            {
                return Content("File Not Exist");
            }
        }

        private byte[] ReadFile(FileStream pFileStream)
        {
            pFileStream.Seek(0, SeekOrigin.Begin);

            
            byte[] pReadByte = new byte[0];

            try
            {

                BinaryReader r = new BinaryReader(pFileStream);
                r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开

                pReadByte = r.ReadBytes((int)r.BaseStream.Length);

                return pReadByte;

            }

            catch

            {

                return pReadByte;

            }

            finally
            {
                
            }

        }
    }
}
