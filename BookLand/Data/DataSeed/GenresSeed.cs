using Bookify.Entities;

namespace Bookify.Data.DataSeed;

public static class GenresSeed
{
    public static List<Genre> GetGenres()
    {
        var genres = new List<Genre>
        {
            new() { GenreName = "Science Fiction"},
            new() { GenreName = "Fantasy"},
            new() { GenreName = "Mystery"},
            new() { GenreName = "Romance"},
            new() { GenreName = "Horror"},
            new() { GenreName = "Thriller"},
            new() { GenreName = "Historical Fiction"},
            new() { GenreName = "Literary Fiction"},
            new() { GenreName = "Adventure"},
            new() { GenreName = "Dystopian"},
            new() { GenreName = "Young Adult (YA)"},
            new() { GenreName = "Urban Fantasy"},
            new() { GenreName = "Paranormal"},
            new() { GenreName = "Steampunk"},
            new() { GenreName = "Magical Realism"}
        };

        return genres;
    }
}
