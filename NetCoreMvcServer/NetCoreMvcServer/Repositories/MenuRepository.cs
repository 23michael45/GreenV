using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class MenuRepository : FonourRepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(GVContext dbcontext) : base(dbcontext)
        {

        }
    }
}
