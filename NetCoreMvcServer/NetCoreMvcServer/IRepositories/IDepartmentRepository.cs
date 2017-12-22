using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public interface IDepartmentRepository : IRepository<Department, Guid>
    {
    }
}
