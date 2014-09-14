using FluentMigrator;
using System;

namespace Migrator
{
    [Migration(201409141939)]
    public class Users : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Users").WithColumn("Id").AsInt32().NotNullable()
                                 .WithColumn("Name").AsString().NotNullable();
                
        }
    }

    [Migration(201409142115)]
    public class AddColumnToUsers : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            Alter.Table("Users").AddColumn("Password").AsString().NotNullable();
        }
    }

}
