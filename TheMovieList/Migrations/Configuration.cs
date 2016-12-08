namespace TheMovieList.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TheMovieList.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TheMovieList.Models.ApplicationDbContext context)
        {
            //seed method is going to be executed every time we run the updata-database command

            var userStore = new UserStore<ApplicationUser>(context); //create a userstore using the movie db set 
            var userManager = new UserManager<ApplicationUser>(userStore); //passing in the user store 

            if (!context.Users.Any(t => t.UserName == "admin@test.com"))  //check if there are an existing user 
            {
                //Declare a new user
                var user = new ApplicationUser
                {
                    UserName = "admin@test.com",
                    Email = "admin@test.com"
                };

                //create the user instantly - no need to save changes
                userManager.Create(user, "passW0rd!");

                //add the new user to this role using the existing record name property 
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole
                {
                    Name = "Admin"
                });

                //updates the database, so that the role exist in the db
                context.SaveChanges();

                //assign my new user to the admin role 
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
