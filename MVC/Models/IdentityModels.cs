using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace MVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("PladespillerenConnection", throwIfV1Schema: false)
        {
            // Database.SetInitializer(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    // custom User & Role initialization
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //var UserManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            //var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //string role = "Admin";
            //string name = "John Doe";
            //string eMail = "john@doe.dk";
            //string password = "password";

            //var user = new IdentityUser();

            //user.UserName = name;
            //user.Email = eMail;

            //user.Roles.Add(new IdentityUserRole() { });
            //UserManager.Create(user, password);

            //RoleManager.Create(new IdentityRole(role));

            //UserManager.AddToRole(user.Id, role);

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var identityRole = new IdentityRole {Name = "Admin"};

                roleManager.Create(identityRole);
            }
            
            if (!context.Users.Any(u => u.UserName == "JohnDoe"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var applicationUser = new ApplicationUser {UserName = "JohnDoe", Email = "john@doe.com"};

                userManager.Create(applicationUser, "password");
                userManager.AddToRole(applicationUser.Id, "Admin");
            }

            base.Seed(context);
        }
    }
}