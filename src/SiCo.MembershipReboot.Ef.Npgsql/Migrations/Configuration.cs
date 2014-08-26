namespace SiCo.MembershipReboot.Ef.Npgsql.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Sql;
    using System.Linq;
    using Npgsql;

    public sealed class Configuration : DbMigrationsConfiguration<SiCo.MembershipReboot.Ef.Npgsql.DefaultMembershipRebootDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("Npgsql", new PostgreSqlMigrationSqlGenerator());
            //SetHistoryContextFactory("Npgsql", (connection, defaultSchema) => new MigrationsHistoryTableNpgsql(connection, defaultSchema));
        }

        protected override void Seed(SiCo.MembershipReboot.Ef.Npgsql.DefaultMembershipRebootDatabase context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
