using Microsoft.Owin;
using Owin;
using WarApp.Models;
//Begin - New content added to display user name - identity/role functionality
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
//END - New content added to display user name - identity/role functionality

[assembly: OwinStartupAttribute(typeof(WarApp.Startup))]
namespace WarApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Begin - New content added to display user name - identity/role functionality
            createRolesandUsers();
            //End - New content added to display user name - identity/role functionality
        }

        //Begin - New content added to display user name - identity/role functionality
        // In this method we will create default User roles and Admin user for login
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User 
            // if (!roleManager.RoleExists("Admin"))
            //{

            // first we create Admin roll
            //var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //role.Name = "Admin";
            //roleManager.Create(role);

            //Here we create a Admin super user who will maintain the website				
            //var user = new ApplicationUser();
            //user.UserName = "adminTest";
            //user.Email = "adminTest.civ@mail.mil";

            //string userPWD = "@dminTest123!";

            //var chkUser = UserManager.Create(user, userPWD);

            //Add default User to Role Admin
            // if (chkUser.Succeeded)
            //{
            //var result1 = UserManager.AddToRole(user.Id, "Admin");

            //}
            //}

            // creating Creating Manager role 
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

            }

            // creating Creating Manager role 
            if (!roleManager.RoleExists("Supervisor"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Supervisor";
                roleManager.Create(role);

            }

            // creating Creating Employee role 
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }
        }
        //END - New content added to display user name - identity/role functionality
    }
}