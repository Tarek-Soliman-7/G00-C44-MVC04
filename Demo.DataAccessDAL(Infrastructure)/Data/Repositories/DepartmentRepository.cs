using Demo.DataAccessDAL_Infrastructure_.Data.Contexts;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessDAL_Infrastructure_.Data.Repositories
{
    public class DepartmentRepository(AppDbContext _dbContext) : GenaricRepository<Department>(_dbContext), IDepartmentRepository
    {

    }
}
