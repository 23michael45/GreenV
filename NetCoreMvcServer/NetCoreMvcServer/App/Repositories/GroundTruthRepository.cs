using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    /// <summary>
    /// 用户管理仓储实现
    /// </summary>
    public class GroundTruthRepository : FonourRepositoryBase<GroundTruth>, IGroundTruthRepository
    {
        public GroundTruthRepository(GVContext dbcontext) : base(dbcontext)
        {
        }


        public GroundTruth GetFromIP(string ip)
        {
            var list = _dbContext.Set<GroundTruth>().Where(it => (it.ip == ip)).OrderBy(it => it.Id);
            if(list != null)
            {

                GroundTruth gt = list.FirstOrDefault<GroundTruth>();
                return gt;
            }
            return null;
        }

    }
}
