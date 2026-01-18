public class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<Book> Books { get; set; } = new List<Book>();
}