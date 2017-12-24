using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    /// <summary>
    /// 用户管理仓储实现
    /// </summary>
    public class App_SensorDataRepository : FonourRepositoryBase<App_SensorData>, IApp_SensorDataRepository
    {
        public App_SensorDataRepository(GVContext dbcontext) : base(dbcontext)
        {

        }
       
    }
}
