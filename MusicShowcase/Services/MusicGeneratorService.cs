using Bogus;
using MusicShowcase.Models;

namespace MusicShowcase.Services
{
    public class MusicGeneratorService
    {
        public List<SongItem> GenerateSongs(string locale, int seed, int page, double avgLikes)
        {
            var faker = new Faker<SongItem>(locale);
            
            faker.UseSeed(seed + page);
            
            int indexer = (page - 1) * 20 + 1;
            
            faker.RuleFor(s => s.Id, f => indexer++)
                .RuleFor(s => s.Title, f => f.Music.Genre() + " " + f.Commerce.ProductName())
                .RuleFor(s => s.Artist, f => f.Name.FullName())
                .RuleFor(s => s.Album, f => f.Commerce.Color() + " " + f.Address.City())
                .RuleFor(s => s.ImageUrl, (f, s) => $"https://picsum.photos/seed/{seed + s.Id}/300/300")
                .RuleFor(s => s.Likes, f => {
                    int baseLikes = (int)Math.Floor(avgLikes);
                    double remainder = avgLikes - baseLikes;
                    return f.Random.Double() < remainder ? baseLikes + 1 : baseLikes;
                });

            return faker.Generate(20); 
        }
    }
}