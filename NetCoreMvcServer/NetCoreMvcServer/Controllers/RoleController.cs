﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NetCoreMvcServer;
using NetCoreMvcServer.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreMvcServer.Controllers
{
    public class RoleController : FonourControllerBase
    {
        private readonly IRoleAppService _service;
        public RoleController(IRoleAppService service, IStringLocalizer<SharedResource> localizer):base(localizer)
        {
            _service = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增或编辑功能
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public IActionResult Edit(RoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    Result = "Faild",
                    Message = GetModelStateError()
                });
            }
            if (dto.Id == Guid.Empty)
                dto.CreateTime = DateTime.Now;
            //dto.CreateUserId = 
            if (_service.InsertOrUpdate(dto))
            {
                return Json(new { Result = "Success" });
            }
            return Json(new { Result = "Faild" });
        }

        public IActionResult GetAllPageList(int startPage, int pageSize)
        {
            int rowCount = 0;
            var result = _service.GetAllPageList(startPage, pageSize, out rowCount);
            return Json(new
            {
                rowCount = rowCount,
                pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
                rows = result,
            });
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
        
    }
}
