using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Migrations
{
    [Migration(202410031831)]
    public class _202410031831_CreateRentTable : Migration
    {
        public override void Up()
        {
            Create.Table("Rents")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("RentFilmTime").AsDate()
                 .WithColumn("ReturnFilmTime").AsDate()
                 .WithColumn("Total").AsDecimal()
                 .WithColumn("RentFilmPrice").AsDecimal()
                 .WithColumn("FilmId").AsInt32()
                 .WithColumn("UserId").AsInt32();
        }
        public override void Down()
        {
            Delete.Table("Rents");
        }

       
    }
}
