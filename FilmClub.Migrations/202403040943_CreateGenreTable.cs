using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Migrations
{
    [Migration(202403040943)]
    public class _202403040943_CreateGenreTable : Migration
    {
        public override void Up()
        {
            Create.Table("Genres")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Title").AsString(50).Nullable()
                .WithColumn("Rate").AsInt32();
        }
        public override void Down()
        {
            Delete.Table("Genres");
        }

      
    }
}
