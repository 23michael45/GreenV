﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public interface ITerminalAppService
    {
        List<TerminalDto> GetTerminalByDepartment(Guid departmentId, int startPage, int pageSize, out int rowCount);

        TerminalDto InsertOrUpdate(TerminalDto dto);

        /// <summary>
        /// 根据Id集合批量删除
        /// </summary>
        /// <param name="ids">Id集合</param>
        void DeleteBatch(List<Guid> ids);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">Id</param>
        void Delete(Guid id);

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        TerminalDto Get(Guid id);
    }
}
