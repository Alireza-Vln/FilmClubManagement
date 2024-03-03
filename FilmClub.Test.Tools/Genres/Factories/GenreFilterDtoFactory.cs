namespace FilmClub.Services.Unit.Test.GenresTest
{
    public static class GenreFilterDtoFactory
    {
       public static GenreFilterDto Create(string? title=null)
        {
            return  new GenreFilterDto
            {
                Title = title?? "dummy-title",
            };
        }
}
}
