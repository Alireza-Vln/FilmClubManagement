using FilmClub.Entities.Films;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistance.EF.Films
{
    public class FilmEntityMap : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).IsRequired();
            builder.Property(_ => _.Poblish).IsRequired();
            builder.Property(_ => _.AgeLimit).IsRequired();
            builder.Property(_ => _.PenaltyRate).IsRequired();
            builder.Property(_ => _.Director).IsRequired();
            builder.Property(_ => _.Count).IsRequired();
            builder.Property(_ => _.Duration).IsRequired();
            builder.Property(_ => _.Description);
            builder.Property(_ => _.Rate).IsRequired();
            builder.Property(_ => _.GenreId).IsRequired();
        }
    }
}
