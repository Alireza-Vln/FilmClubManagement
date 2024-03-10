using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Migrations
{
    [Migration(202403061149)]
    public class _202403061149_CreateUserTable : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(50).NotNullable()
                .WithColumn("LastName").AsString(50).NotNullable()
                .WithColumn("PhoneNumber").AsString(50).NotNullable()
                .WithColumn("Address").AsString(500).NotNullable()
                .WithColumn("Age").AsDate().NotNullable()
                .WithColumn("Gender").AsInt32().NotNullable()
                .WithColumn("Rate").AsDecimal();

        }
        public override void Down()
        {
            Delete.Table("Users");
        }

      
    }
}
