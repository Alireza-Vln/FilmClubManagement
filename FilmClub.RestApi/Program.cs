using FilmClub.Services.Films;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Genres;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Unit.Test.GenresTest.GenreTests;
using FilmClubManagement.Persistance.EF;
using FilmClubManagement.Persistance.EF.Films;
using FilmClubManagement.Persistance.EF.Genres;
using FilmClubs.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("appsettings.json");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EFDataContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<GenreManageService, GenreManageAppService>();
builder.Services.AddScoped<GenreService, GenreAppService>();
builder.Services.AddScoped<GenreRepository,EFGenreRepository>();
builder.Services.AddScoped<FilmRepository, EFFilmRepository>();
builder.Services.AddScoped<FilmService, FilmAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
