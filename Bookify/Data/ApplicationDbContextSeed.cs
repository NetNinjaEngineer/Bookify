using Bookify.Data.DataSeed;

namespace Bookify.Data;

public static class ApplicationDbContextSeed
{
    public static async Task SeedDatabaseAsync(this ApplicationDbContext dbContext)
    {
        if (!dbContext.Authors.Any())
        {
            await dbContext.Authors.AddRangeAsync(AuthorsSeed.GetAuthors());
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Genres.Any())
        {
            await dbContext.Genres.AddRangeAsync(GenresSeed.GetGenres());
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Publishers.Any())
        {
            await dbContext.Publishers.AddRangeAsync(PublishersSeed.LoadPublishers());
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Tags.Any())
        {
            await dbContext.Tags.AddRangeAsync(TagsSeed.LoadTags());
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Books.Any())
        {
            await dbContext.Books.AddRangeAsync(BooksSeed.GetBooks());
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.DeliveryMethods.Any())
        {
            await dbContext.DeliveryMethods.AddRangeAsync(DeliveryMethodsSeed.GetDeliveryMethods());
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.BookTags.Any())
        {
            await dbContext.BookTags.AddRangeAsync(BookTagsSeed.LoadBookTags());
            await dbContext.SaveChangesAsync();
        }

    }
}
