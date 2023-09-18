using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ETicaretMvcWebUi.Models
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            // Rolleri
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Detay = "admin rolü" };
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Detay = "user rolü" }; ;
                manager.Create(role);
            }

            if (!context.Users.Any(i => i.Ad == "ismailaktas"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Ad = "ismail", Soyad = "aktas", UserName = "ismailaktas", Email = "ismail@gmail.com" };

                manager.Create(user, "ismail123");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }





            base.Seed(context);
        }
    }
}