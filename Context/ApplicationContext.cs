using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    public class ApplicationContext:DbContext 
    {
        public DbSet<Reminder> reminders {  get; set; }
        public DbSet<Department> Departments { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
        }
    }
}
