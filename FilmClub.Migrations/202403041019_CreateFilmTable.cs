using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Migrations
{
    [Migration(202403041019)]
    public class _202403041019_CreateFilmTable : Migration
    {
        public override void Up()
        {
            Create.Table("Films")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Director").AsString(50).NotNullable()
                .WithColumn("Description").AsString()
                .WithColumn("Poblish").AsString().NotNullable()
                .WithColumn("AgeLimit").AsInt32().NotNullable()
                .WithColumn("PenaltyRate").AsInt32()
                .WithColumn("Duration").AsInt32()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("Rate").AsInt32().NotNullable()
                .WithColumn("GenreId").AsInt32().NotNullable();
        }
        public override void Down()
        {
            Create.Table("Films");
        }

       
    }
}
