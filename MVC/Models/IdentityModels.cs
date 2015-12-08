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
            Database.SetInitializer(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    // Custom user & role initialization
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            string adminRole = "Admin";
            string adminUser = "AdminUser";

            string companyRole = "Company";
            string companyUser = "CompanyUser";

            string userRole = "User";
            string regularUser = "RegularUser";


            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var adminIdentityRole = new IdentityRole { Name = adminRole };
            roleManager.Create(adminIdentityRole);

            var companyIdentityRole = new IdentityRole { Name = companyRole };
            roleManager.Create(companyIdentityRole);

            var userIdentityRole = new IdentityRole { Name = userRole };
            roleManager.Create(userIdentityRole);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);


            var applicationAdmin = new ApplicationUser { UserName = adminUser, Email = "admin@plade.com" };
            userManager.Create(applicationAdmin, "password");
            userManager.AddToRole(applicationAdmin.Id, adminRole);

            var applicationCompany = new ApplicationUser { UserName = companyUser, Email = "company@plade.com" };
            userManager.Create(applicationCompany, "password");
            userManager.AddToRole(applicationCompany.Id, companyRole);

            var applicationUser = new ApplicationUser { UserName = regularUser, Email = "user@plade.com" };
            userManager.Create(applicationUser, "password");
            userManager.AddToRole(applicationUser.Id, userRole);


            base.Seed(context);
        }
    }
}