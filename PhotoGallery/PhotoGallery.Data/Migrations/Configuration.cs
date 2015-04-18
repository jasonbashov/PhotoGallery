namespace PhotoGallery.Data.Migrations
{
    using PhotoGallery.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoGalleryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhotoGallery.Data.PhotoGalleryDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            //password 123123
            this.AddUsers(context);
        }

        private void AddUsers(PhotoGalleryDbContext context)
        {
            var testUser = new User()
            {
                Email = "test@test.bg",
                UserName = "test@test.bg",
                PasswordHash = "AEyfEgPZuktSCzOcsvfkpK0F/y9j4VxEatUYcnVIwqeBnZZ53L1rzuKzZWhuug5Kkw==",
                SecurityStamp = "7cd5c4c9-61ba-41e0-9a6a-f5148bdd5715"
            };

            var testUserToBeClient = new User()
            {
                Email = "testClient@test.bg",
                UserName = "testClient@test.bg",
                PasswordHash = "AEyfEgPZuktSCzOcsvfkpK0F/y9j4VxEatUYcnVIwqeBnZZ53L1rzuKzZWhuug5Kkw==",
                SecurityStamp = "7cd5c4c9-61ba-41e0-9a6a-f5148bdd5715"
            };

            context.Users.Add(testUser);
            context.Users.Add(testUserToBeClient);
            context.SaveChanges();
        }
    }
}
