using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TemplatePOC.Web.Models.LogIn.POCO;

namespace TemplatePOC.Web.Models.LogIn
{
    public class LogInContext:DbContext
    {
        public DbSet<AdminUser> AdminUsers { get; set; }

        public DbSet<ResellerUser> ResellerUsers { get; set; }

        public LogInContext()
            : base("name=default")
        {
            Database.SetInitializer<LogInContext>(new LogInContextInitializer());
        }
    }
}