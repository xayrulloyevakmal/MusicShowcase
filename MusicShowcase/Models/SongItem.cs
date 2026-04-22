namespace MusicShowcase.Models
{
    public class SongItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public int Likes { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}