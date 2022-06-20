using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrationsTest.FluentMigrator.Migrations
{
    [Migration(2)]
    public class Script002_IncreasePersonFirstNameLength : Migration
    {
        public override void Down()
        {
            Alter.Table("Person")
                .AlterColumn("FirstName").AsString(255);
        }

        public override void Up()
        {
            Alter.Table("Person")
                .AlterColumn("FirstName").AsString(500);
        }
    }
}
