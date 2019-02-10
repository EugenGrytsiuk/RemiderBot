using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.AppSetting
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("DbConnection")
        { }

        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<Employe> Employes { get; set; }
    }
}
