namespace iocco_api.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using iocco_api.BusinessLayer;
    public partial class EmployeeDatabase : DbContext, IDbContext
    {
        public EmployeeDatabase()
            : base("name=EmployeeDatabase") //change this to config
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
