namespace NotDefteriApi.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using NotDefteriApi.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NotDefteriApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NotDefteriApi.Models.ApplicationDbContext context)
        {
            var kullaniciEmail = "ornek@gmail.com";

            if (!context.Users.Any(x => x.UserName == kullaniciEmail))
            {
                #region Örnek Kullanýcýyý Oluþtur
                var kullanici = new ApplicationUser()
                {
                    UserName = kullaniciEmail,
                    Email = kullaniciEmail,
                    EmailConfirmed = true
                };
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new ApplicationUserManager(userStore);
                userManager.Create(kullanici, "Ankara1.");
                #endregion
            }
        }
    }
}
