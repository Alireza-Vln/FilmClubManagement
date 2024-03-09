namespace FilmClub.Services.Unit.Test.FilmsTest
{
    public static class UpdateFilmDtoFactory
    {
        public static UpdateFilmDto Create(
            int genreId,
             string ?name=null,
             string ? director=null)
        {
            return new UpdateFilmDto
            {
                Name =name??  "Update_dummy-name",
                Director = director??"dummy-director",
                Poblish = "dummy-polish",
                AgeLimit = 180,
                Count = 12,
                PenaltyRate = 21,
                Duration = 11,
                Description = "Update_dummy-description",
                Rate = 12,
                GenreId = genreId,
            };
        }
    }
}
