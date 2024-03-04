﻿namespace FilmClub.Services.Unit.Test.FilmsTest
{
    public static class FilmFilterDtoFactory
    {
        public static FilmFilterDto Create
            (string? name = null,
            string? director = null,
            string? genre = null)
        {
            return new FilmFilterDto
            {
                Name = name ?? "dummy-name",
                Director = director ?? "dummy-director",
                GenreName = genre
            };
        }

    }
}