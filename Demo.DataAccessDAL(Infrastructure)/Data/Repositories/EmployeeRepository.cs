using Demo.DataAccessDAL_Infrastructure_.Data.Repositories.Interfaces;
using Demo.DataAccessDAL_Infrastructure_.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessDAL_Infrastructure_.Models;

namespace Demo.DataAccessDAL_Infrastructure_.Data.Repositories
{
    public class EmployeeRepository(AppDbContext _dbContext):GenaricRepository<Employee>(_dbContext),IEmployeeRepository
    {
        
    }
}
