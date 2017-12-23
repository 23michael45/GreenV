using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreMvcServer.Models;

namespace NetCoreMvcServer.Controllers
{
    public class App_SensorDataController : Controller
    {
        private readonly GVContext _context;

        public App_SensorDataController(GVContext context)
        {
            _context = context;
        }

        // GET: App_SensorData
        public async Task<IActionResult> Index()
        {
            return View(await _context.App_SensorData.ToListAsync());
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

        // GET: App_SensorData/Delete/5
        public async Task<IActionResult> Delete(Guid id)
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
    }
}
