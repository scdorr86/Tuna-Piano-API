using Microsoft.EntityFrameworkCore;
using Tuna_Piano_API.Models;
using System.Runtime.CompilerServices;

public class TunaPianoDbContext : DbContext
{

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Artist>().HasData(new Artist[]
        {
            new Artist {Id = 1, Name = "Sevendust", Age = 30, Bio = "Long running metal band"},
            new Artist {Id = 2, Name = "Hoobastank", Age = 30, Bio = "All-time Tune Maker"},
            new Artist {Id = 3, Name = "Staind", Age = 30, Bio = "Metal Fav"},
        });

        modelBuilder.Entity<Song>().HasData(new Song[]
        {
            new Song { Id = 1, Title = "Broken Down", ArtistId = 1, GenreId= 2, Album = "Seasons", Length = new TimeSpan(0, 3, 30) },
            new Song { Id = 2, Title = "Crawling in the Dark", ArtistId = 2, GenreId = 2, Album = "Hoobastank", Length = new TimeSpan(0, 2, 55) },
            new Song { Id = 3, Title = "Fade", ArtistId= 3, GenreId = 1, Album = "Break the Cycle", Length = new TimeSpan(0, 3, 20) },
        });


        modelBuilder.Entity<Genre>().HasData(new Genre[]
        {
            new Genre { Id = 1, Description = "Metal"},
            new Genre { Id = 2, Description = "Rock"},
        });
    }
}