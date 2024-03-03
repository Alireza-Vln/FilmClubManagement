﻿namespace FilmClub.Services.Films.Contracts.Dtos
{
    public class AddFilmDto
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string? Description { get; set; }
        public string Poblish { get; set; }
        public int AgeLimit { get; set; }
        public int PenaltyRate { get; set; }
        public int Duration { get; set; }
        public int Count { get; set; }
        public int Rate { get; set; }
        public int GenreId { get; set; }
    }
}
