public class Illustrator : Person
{
    public IEnumerable<Book> Books { get; set; } = new List<Book>();
}