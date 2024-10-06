using Bookify.Data.DataSeed;

namespace Bookify.Data;

public static class ApplicationDbContextSeed
{
    public static async Task SeedDatabaseAsync(this ApplicationDbContext dbContext)
    {
        if (!dbContext.Genres.Any())
        {
            await dbContext.Genres.AddRangeAsync(GenresSeed.GetGenres());
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Books.Any())
        {
            await dbContext.Books.AddRangeAsync(BooksSeed.GetBooks());
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Authors.Any())
        {
            await dbContext.Authors.AddRangeAsync(AuthorsSeed.GetAuthors());
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.DeliveryMethods.Any())
        {
            await dbContext.DeliveryMethods.AddRangeAsync(DeliveryMethodsSeed.GetDeliveryMethods());
            await dbContext.SaveChangesAsync();
        }
    }
}
