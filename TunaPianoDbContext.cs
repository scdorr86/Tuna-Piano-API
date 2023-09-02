using Microsoft.EntityFrameworkCore;
using Tuna_Piano_API.Models;
using System.Runtime.CompilerServices;

public class TunaPianoDbContext : DbContext
{

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<SongGenre> SongGenres { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<Artist>().HasData(new Artist[]
        {
        new Artist {Id = 1, Name = "Sevendust", Age = 30, Bio = "Long running metal band"},
        });
    }
}