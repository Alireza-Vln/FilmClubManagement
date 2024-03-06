using FilmClub.Services.Unit.Test.UsersTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistance.EF.Users
{
    public class UserEntityMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_=>_.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.FirstName).IsRequired();
            builder.Property(_ => _.LastName).IsRequired();
            builder.Property(_=>_.Age).IsRequired();
            builder.Property(_ => _.Gender);
            builder.Property(_ => _.Address).IsRequired();
            builder.Property(_ => _.PhoneNumber).IsRequired();

        }
    }
}
