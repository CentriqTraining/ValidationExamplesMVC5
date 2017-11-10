using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Entities
{
    public class HrContext : DbContext
    {
        public HrContext()
        {
            Database.SetInitializer<HrContext>(new DBInit());
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
