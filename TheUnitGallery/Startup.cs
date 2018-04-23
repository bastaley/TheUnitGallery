using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TheUnitGallery.Models;

[assembly: OwinStartupAttribute(typeof(TheUnitGallery.Startup))]
namespace TheUnitGallery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
            createAboutBlockAndHomePage();

        }

        private void createAboutBlockAndHomePage()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            //Setting up homepage
            if (context.Pages.Find("homepage") == null)
            {
                //Create the about us block
                var AboutBlock = new Block();

                    AboutBlock.Name = "AboutUs";
                    AboutBlock.Content = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non semper quam. In hac habitasse platea dictumst. Integer tellus eros, facilisis non diam at, pellentesque vestibulum sapien. Praesent volutpat imperdiet neque, quis pretium orci consectetur eget. Aliquam maximus eu nibh vitae ultricies. Aenean bibendum bibendum laoreet.</p><p> Lorem ipsum dolor sit amet, consectetur adipiscing elit.In scelerisque nibh magna, eu scelerisque lectus blandit eget.Lorem ipsum dolor sit amet, consectetur adipiscing elit.In scelerisque nibh magna, eu scelerisque lectus blandit eget.</p>";

                // create a page called homepage    
                var homepage = new Page
                {
                    Identifier = "homepage",
                    Title = "Modern Art At The Unit",
                    Content = AboutBlock,
                };
            }
        }


        // In this method we will create default User roles and Admin user for login    
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool    
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   
                var user = new ApplicationUser
                {
                    UserName = "ben@staley.com",
                    Email = "ben@staley.com"
                };

                string userPWD = "Poppy1£";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // creating Creating Manager role     
            if (!roleManager.RoleExists("Staff"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
                {
                    Name = "Staff"
                };
                roleManager.Create(role);

            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
                {
                    Name = "Customer"
                };
                roleManager.Create(role);
            }
        }
    }
}
