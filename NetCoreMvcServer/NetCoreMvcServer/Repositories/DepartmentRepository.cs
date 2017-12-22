using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class DepartmentRepository : FonourRepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(GVContext dbcontext) : base(dbcontext)
        {

        }
    }
}
