namespace Exercise17Gym.Migrations
{
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

   /*         
Seeda en roll som heter �admin�.
Seeda en anv�ndare med anv�ndarnamnet �admin @Gymbokning.se� och valfritt hemligt l�senord.
L�gg till anv�ndaren �admin @Gymbokning.se� i rollen
*/





        }
    }
}
