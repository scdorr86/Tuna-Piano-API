namespace Tuna_Piano_API.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public string Album { get; set; }
        public DateTime length { get; set; }
    }
}
