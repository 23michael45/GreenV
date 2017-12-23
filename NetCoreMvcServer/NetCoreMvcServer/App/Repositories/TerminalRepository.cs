using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    /// <summary>
    /// 用户管理仓储实现
    /// </summary>
    public class TerminalRepository : FonourRepositoryBase<Terminal>, ITerminalRepository
    {
        public TerminalRepository(GVContext dbcontext) : base(dbcontext)
        {
        }


        public Terminal GetFromIP(string ip)
        {
            var list = _dbContext.Set<Terminal>().Where(it => (it.ip == ip)).OrderBy(it => it.Id);
            Terminal terminal = list.FirstOrDefault<Terminal>();
            return terminal;
        }

    }
}
