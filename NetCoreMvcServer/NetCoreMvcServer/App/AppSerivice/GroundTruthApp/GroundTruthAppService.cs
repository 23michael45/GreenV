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
    public class GroundTruthAppService : IGroundTruthAppService
    {
        //用户管理仓储接口
        private readonly IGroundTruthRepository _repository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="userRepository">仓储对象</param>
        public GroundTruthAppService(IGroundTruthRepository GroundTruthRepository)
        {
            _repository = GroundTruthRepository;
        }
        
        public List<GroundTruthDto> GetGroundTruthByDepartment(Guid departmentId, int startPage, int pageSize, out int rowCount)
        {
            return Mapper.Map<List<GroundTruthDto>>(_repository.LoadPageList(startPage, pageSize, out rowCount, it => it.DepartmentId == departmentId, it => it.ip));
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public GroundTruthDto InsertOrUpdate(GroundTruthDto dto)
        {
            if (Get(dto.Id) != null)
                _repository.Delete(dto.Id);


            GroundTruth t = _repository.GetFromIP(dto.ip);
            if (t != null)
            {
                _repository.Delete(t.Id);
            }
            var GroundTruth = _repository.InsertOrUpdate(Mapper.Map<GroundTruth>(dto));
            return Mapper.Map<GroundTruthDto>(GroundTruth);
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
        public GroundTruthDto Get(Guid id)
        {
            return Mapper.Map<GroundTruthDto>(_repository.Get(id));
        }
    }
}
