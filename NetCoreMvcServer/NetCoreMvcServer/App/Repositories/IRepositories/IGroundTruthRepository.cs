using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    /// <summary>
    /// 用户管理仓储接口
    /// </summary>
    public interface IGroundTruthRepository : IRepository<GroundTruth>
    {
        GroundTruth GetFromIP(string ip);
    }
}
