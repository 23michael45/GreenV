using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreMvcServer.Models;

namespace NetCoreMvcServer.Controllers
{
    public class App_GroundTruthDataController : Controller
    {
        private readonly GVContext _context;
        private readonly IApp_GroundTruthDataRepository _repository;

        static Dictionary<string, byte[]> _TempDataDic = new Dictionary<string, byte[]>();

        public App_GroundTruthDataController(GVContext context, IApp_GroundTruthDataRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: App_GroundTruthData
        public async Task<IActionResult> Index()
        {
            return View(await _context.App_GroundTruthData.ToListAsync());
        }

        // GET: App_GroundTruthData/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var App_GroundTruthData = await _context.App_GroundTruthData
                .SingleOrDefaultAsync(m => m.Id == id);
            if (App_GroundTruthData == null)
            {
                return NotFound();
            }

            return View(App_GroundTruthData);
        }

        // GET: App_GroundTruthData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: App_GroundTruthData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,device,timestamps,timestampms,sendsorvalue")] App_GroundTruthData App_GroundTruthData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(App_GroundTruthData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(App_GroundTruthData);
        }

        // GET: App_GroundTruthData/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var App_GroundTruthData = await _context.App_GroundTruthData.SingleOrDefaultAsync(m => m.Id == id);
            if (App_GroundTruthData == null)
            {
                return NotFound();
            }
            return View(App_GroundTruthData);
        }

        // POST: App_GroundTruthData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,device,timestamps,timestampms,sendsorvalue")] App_GroundTruthData App_GroundTruthData)
        {
            if (id != App_GroundTruthData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(App_GroundTruthData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!App_GroundTruthDataExists(App_GroundTruthData.Id))
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
            return View(App_GroundTruthData);
        }



        // POST: App_GroundTruthData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var App_GroundTruthData = await _context.App_GroundTruthData.SingleOrDefaultAsync(m => m.Id == id);
            _context.App_GroundTruthData.Remove(App_GroundTruthData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool App_GroundTruthDataExists(Guid id)
        {
            return _context.App_GroundTruthData.Any(e => e.Id == id);
        }

        public IActionResult GetDataByDepartment(int startPage, int pageSize, Guid departmentId)
        {
            return Content(departmentId.ToString());
        }
        public IActionResult Query(int startPage, int pageSize, string dt, string ip)
        {

            IQueryable<App_GroundTruthData> rt = DoQuery(dt, ip);
            rt = rt.Skip((startPage - 1) * pageSize).Take(pageSize);
            int totalCount = rt.Count();
            return Json(new
            {
                rowCount = totalCount,
                pageCount = Math.Ceiling(Convert.ToDecimal(totalCount) / pageSize),
                rows = rt
            });




        }
        IQueryable<App_GroundTruthData> DoQuery(string dt, string ip)
        {
            //12/25/2017 4:00 AM - 12/25/2017 11:59 PM
            string[] times = dt.Split('-');

            DateTime starttime = DateTime.Parse(times[0]);
            DateTime endtime = DateTime.Parse(times[1]);
            IQueryable<App_GroundTruthData> rt = null;

            if (ip == null || ip == "" || ip == "undefined")
            {
                rt = _context.App_GroundTruthData.Where(item => (item.createtime > starttime && item.createtime < endtime)).OrderBy(it => it.createtime);

            }
            else
            {
                rt = _context.App_GroundTruthData.Where(item => (item.device == ip) && (item.createtime > starttime && item.createtime < endtime)).OrderBy(it => it.createtime);

            }
            return rt;
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
            IQueryable<App_GroundTruthData> rt = DoQuery(dt, ip);
            byte[] content = SaveSensor(rt.OrderBy(it => it.createtime));

            Guid id = Guid.NewGuid();
            string handle = id.ToString();
            _TempDataDic[handle] = content;

            return Json(new
            {
                fileGuid = handle,
                fileName = "groundtruth.txt",
            });
        }

        byte[] SaveSensor(IQueryable<App_GroundTruthData> list)
        {
            if (list == null)
            {
                return null;
            }

            FileStream fs = new FileStream("groundtruth.txt", FileMode.OpenOrCreate);
            var file = new System.IO.StreamWriter(fs);
            foreach (App_GroundTruthData asd in list)
            {


                Guid id = asd.Id;
                string device = asd.device;
                int leftright = asd.leftright;
                long timestamp = asd.timestamp;
                DateTime createtime = asd.createtime;



                string s = string.Format("id:{0} device:{1} createtime:{2} timestamp:{3} leftright:{4} ", id, device,createtime, timestamp, leftright);
                
                file.WriteLine(s);
                
            }

            file.Flush();

            byte[] filecontent = ReadFile(fs);

            fs.Close();

            return filecontent;
        }
        [HttpGet]
        public virtual ActionResult Download(string fileGuid, string fileName)
        {

            if (_TempDataDic[fileGuid] != null)
            {
                byte[] data = _TempDataDic[fileGuid] as byte[];
                return File(data, "application/vnd.ms-excel", fileName);
            }
            else
            {
                // Problem - Log the error, generate a blank file,
                //           redirect to another controller action - whatever fits with your application
                return new EmptyResult();
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
