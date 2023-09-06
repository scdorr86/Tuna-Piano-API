using Tuna_Piano_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:7040")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<TunaPianoDbContext>(builder.Configuration["TunaPianoDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

//Add for Cors 
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// SONG ENDPOINTS:

app.MapGet("/api/songs", (TunaPianoDbContext db) =>
{
    return db.Songs.ToList();
});

app.MapGet("/api/songs/{id}", (TunaPianoDbContext db, int id) =>
{
    return db.Songs.Include(s => s.Artist).Single(s => s.Id == id);
});

app.MapDelete("/api/songs/{id}", (TunaPianoDbContext db, int id) =>
{
    Song songToDelete = db.Songs.SingleOrDefault(song => song.Id == id);
    if (songToDelete == null)
    {
        return Results.NotFound();
    }
    db.Songs.Remove(songToDelete);
    db.SaveChanges();
    return Results.Ok(db.Songs);

});

app.MapPut("/api/songs/{id}", (TunaPianoDbContext db, int id, Song song) =>
{
    Song songToUpdate = db.Songs.SingleOrDefault(s => s.Id == id);
    if (songToUpdate == null)
    {
        return Results.NotFound();
    }
    songToUpdate.Title = song.Title;
    songToUpdate.ArtistId = song.ArtistId;
    songToUpdate.Album = song.Album;
    songToUpdate.Length = song.Length;

    db.SaveChanges();
    return Results.NoContent();
});

app.MapPost("/api/songs", (TunaPianoDbContext db, Song song) =>
{
    db.Songs.Add(song);
    db.SaveChanges();
    return Results.Created($"/api/songs/{song.Id}", song);
});

// ARTIST ENDPOINTS

app.MapGet("/api/artists", (TunaPianoDbContext db) =>
{
    return db.Artists.ToList();
});

app.MapGet("/api/artists/{id}", (TunaPianoDbContext db, int id) =>
{
    return db.Artists.Include(a => a.Id == id);
});

app.MapDelete("/api/artists/{id}", (TunaPianoDbContext db, int id) =>
{
    Artist artistToDelete = db.Artists.SingleOrDefault(a => a.Id == id);
    if (artistToDelete == null)
    {
        return Results.NotFound();
    }
    db.Artists.Remove(artistToDelete);
    db.SaveChanges();
    return Results.Ok(db.Artists);

});

app.MapPut("/api/artists/{id}", (TunaPianoDbContext db, int id, Artist artist) =>
{
    Artist artistToUpdate = db.Artists.SingleOrDefault(a => a.Id == id);
    if (artistToUpdate == null)
    {
        return Results.NotFound();
    }
    artistToUpdate.Name = artist.Name;
    artistToUpdate.Age = artist.Age;
    artistToUpdate.Bio = artist.Bio;
    
    db.SaveChanges();
    return Results.Ok(artistToUpdate);
});

app.MapPost("/api/artists", (TunaPianoDbContext db, Artist artist) =>
{
    db.Artists.Add(artist);
    db.SaveChanges();
    return Results.Created($"/api/artists/{artist.Id}", artist);
});

// GENRE ENDPOINTS:

app.MapGet("/api/genres", (TunaPianoDbContext db) =>
{
    return db.Genres.ToList();
});

app.MapGet("/api/genres/{id}", (TunaPianoDbContext db, int id) =>
{
    return db.Genres.Include(g => g.Id == id);
});

app.MapPost("/api/genres", (TunaPianoDbContext db, Genre genre) =>
{
    db.Genres.Add(genre);
    db.SaveChanges();
    return Results.Created($"/api/genres/{genre.Id}", genre);
});

app.MapPut("/api/genres/{id}", (TunaPianoDbContext db, int id, Genre genre) =>
{
    Genre genreToUpdate = db.Genres.SingleOrDefault(g => g.Id == id);
    if (genreToUpdate == null)
    {
        return Results.NotFound();
    }
    
    genreToUpdate.Description = genre.Description;

    db.SaveChanges();
    return Results.Ok(genreToUpdate);
});

app.MapDelete("/api/genres/{id}", (TunaPianoDbContext db, int id) =>
{
    Genre genreToDelete = db.Genres.SingleOrDefault(g => g.Id == id);
    if (genreToDelete == null)
    {
        return Results.NotFound();
    }
    db.Genres.Remove(genreToDelete);
    db.SaveChanges();
    return Results.Ok(db.Genres);

});



app.Run();

