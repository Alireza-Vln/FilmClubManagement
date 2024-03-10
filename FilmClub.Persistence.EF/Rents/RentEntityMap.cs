using FilmClub.Services.Rents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistance.EF.Rents
{
    public class RentEntityMap : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.FilmId).IsRequired();
            builder.Property(_ => _.UserId).IsRequired();
            builder.Property(_ => _.RentFilmPrice);
            builder.Property(_=>_.RentFilmTime).IsRequired();
            builder.Property(_=>_.RentFilmTime).IsRequired();
            builder.Property(_=>_.Total).IsRequired();
        }
    }
}
