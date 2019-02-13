namespace CI203_semester_2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    
    internal sealed class Configuration : DbMigrationsConfiguration<CI203_semester_2.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

    
        protected override void Seed(CI203_semester_2.BookContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }      
    }
}
