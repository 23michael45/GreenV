using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class RoleRepository : FonourRepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(GVContext dbcontext) : base(dbcontext)
        {

        }
    }
}

