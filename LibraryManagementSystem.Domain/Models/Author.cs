public class Author : Person
{
    public IEnumerable<Book> Books { get; set; } = new List<Book>();
}