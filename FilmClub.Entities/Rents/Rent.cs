using FilmClub.Entities.Films;
using FilmClub.Services.Unit.Test.UsersTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Services.Rents
{
    public class Rent
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public Film Films { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime RentFilmTime { get; set; }
        public DateTime ReturnFilmTime { get; set; }
        public decimal RentFilmPrice { get; set;}
        public decimal Total { get; set; }

    }
}
