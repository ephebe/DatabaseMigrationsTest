using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrationsTest.FluentMigrator.Migrations
{
    [Migration(1)]
    public class Script001_CreatePersonTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Person");
        }

        public override void Up()
        {
            Create.Table("Person")
                .WithColumn("PersonId").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(255).NotNullable()
                .WithColumn("LastName").AsString(255).NotNullable()
                .WithColumn("DateOfBirth").AsDate().NotNullable();
        }
    }
}
