using WeCanFixIt.Web.Models;

namespace WeCanFixIt.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Jobs.AddOrUpdate(a => a.Id, new Job[]
            {
                new Job {Id = 1,WorkType = "painter",Date = DateTime.Now},
                new Job {Id = 2,WorkType = "plumber",Date = DateTime.Now},
                new Job {Id = 3,WorkType = "electrician",Date = DateTime.Now},
                new Job {Id = 4,WorkType = "furniture maker",Date = DateTime.Now}
            });
        }
    }
}
