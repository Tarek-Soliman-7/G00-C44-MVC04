
using System.Reflection;


namespace Demo.DataAccessDAL_Infrastructure_.Data.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("ConnectionString");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }   
        public DbSet<Department> Departments {  get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
