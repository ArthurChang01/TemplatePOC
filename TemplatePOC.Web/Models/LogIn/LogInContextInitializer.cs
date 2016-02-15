using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TemplatePOC.Web.Models.LogIn.POCO;

namespace TemplatePOC.Web.Models.LogIn
{
    public class LogInContextInitializer
        :DropCreateDatabaseIfModelChanges<LogInContext>
    {
        protected override void Seed(LogInContext context)
        {
            context.AdminUsers.Add(new AdminUser() {
                UserName="Admin",
                Password="Admin"
            });

            context.ResellerUsers.Add(new ResellerUser() {
                Code="Reseller",
                UserName="Reseller",
                Password="Reseller"
            });

            context.SaveChanges();
        }
    }
}