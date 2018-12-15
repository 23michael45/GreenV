using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    /// <summary>
    /// 用户管理仓储实现
    /// </summary>
    public class App_GroundTruthDataRepository : FonourRepositoryIntBase<App_GroundTruthData>, IApp_GroundTruthDataRepository
    {
        public App_GroundTruthDataRepository(GVContext dbcontext) : base(dbcontext)
        {

        }
       
    }
}
