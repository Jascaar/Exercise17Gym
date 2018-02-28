namespace Exercise17Gym.Migrations
{
    using Exercise17Gym.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Exercise17Gym.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Exercise17Gym.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleNames = new[] { Role.Admin, Role.Member };
            foreach (var roleName in roleNames)
            {
                if (context.Roles.Any(r => r.Name == roleName)) continue;

                // Create role
                var role = new IdentityRole { Name = roleName };
                var result = roleManager.Create(role);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var emails = new[] { "member@gym.xom", "admin@gym.xom", "valentina@gym.xom" };
            foreach (var email in emails)
            {
                if (context.Users.Any(u => u.UserName == email)) continue;

                // Create user
                var user = new ApplicationUser { FirstName = email.Substring(0,email.IndexOf('@')), Email = email, UserName=email,LastName= "Испытуемый" };
                var result = userManager.Create(user, "BakinPotatoes");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            }
            var adminUser = userManager.FindByName("admin@gym.xom");
            userManager.AddToRole(adminUser.Id, Role.Admin);

            var MemberUser = userManager.FindByName("member@gym.xom");
            userManager.AddToRole(MemberUser.Id, Role.Member);

            var валентина = userManager.FindByName("valentina@gym.xom");
            userManager.AddToRoles(валентина.Id, Role.Admin, Role.Member);
        }
    }

}
