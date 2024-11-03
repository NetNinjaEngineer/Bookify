namespace Bookify.Entities;

public class Return : BaseEntity
{
    public DateTimeOffset ReturnDate { get; set; } = DateTimeOffset.UtcNow;
    public int? OrderId { get; set; }
}
