using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NetCoreMvcServer.Models
{
    /// <summary>
    /// 用户管理服务
    /// </summary>
    public class TerminalAppService : ITerminalAppService
    {
        //用户管理仓储接口
        private readonly ITerminalRepository _repository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="userRepository">仓储对象</param>
        public TerminalAppService(ITerminalRepository terminalRepository)
        {
            _repository = terminalRepository;
        }
        
        public List<TerminalDto> GetTerminalByDepartment(Guid departmentId, int startPage, int pageSize, out int rowCount)
        {
            return Mapper.Map<List<TerminalDto>>(_repository.LoadPageList(startPage, pageSize, out rowCount, it => it.DepartmentId == departmentId, it => it.ip));
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public TerminalDto InsertOrUpdate(TerminalDto dto)
        {
            if (Get(dto.Id) != null)
                _repository.Delete(dto.Id);

            if (_repository.Get(dto.ip) != null)
                _repository.Delete(dto.Id);

            var terminal = _repository.InsertOrUpdate(Mapper.Map<Terminal>(dto));
            return Mapper.Map<TerminalDto>(terminal);
        }
        /// <summary>
        /// 根据Id集合批量删除
        /// </summary>
        /// <param name="ids">Id集合</param>
        public void DeleteBatch(List<Guid> ids)
        {
            _repository.Delete(it => ids.Contains(it.Id));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">Id</param>
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public TerminalDto Get(Guid id)
        {
            return Mapper.Map<TerminalDto>(_repository.Get(id));
        }
    }
}
