using Demo.DataAccessDAL_Infrastructure_.Data.Contexts;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessDAL_Infrastructure_.Data.Repositories
{
    public class DepartmentRepository(AppDbContext _dbContext) : IDepartmentRepository
    {



        //5 CRUD Operations

        // GET ALL
        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _dbContext.Departments.ToList();
            return _dbContext.Departments.AsNoTracking().ToList();

        }

        // GET BY ID
        public Department? GetById(int id) => _dbContext.Departments.Find(id);

        // ADD
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }

        // UPDATE
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }

        // REMOVE
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }
    }
}
