using Demo.DataAccessDAL_Infrastructure_.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessDAL_Infrastructure_.Data.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e=>e.HiringDate).HasDefaultValueSql("GETDATE()");
            builder.Property(e=>e.Gender).HasConversion((EmpGender)=>EmpGender.ToString(),(G)=> (Gender)Enum.Parse(typeof(Gender),G));
            builder.Property(e=>e.EmployeeType).HasConversion((EmpType)=>EmpType.ToString(),(T)=> (EmpType)Enum.Parse(typeof(EmpType),T));

        }
    }
}
