using System.ComponentModel.DataAnnotations;

namespace Tuna_Piano_API.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
    }
}
