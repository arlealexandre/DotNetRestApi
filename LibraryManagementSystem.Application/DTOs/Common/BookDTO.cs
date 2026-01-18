namespace LibraryManagementSystem.Application.DTOs;

public class BookDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ushort PublicationYear { get; set; }
    public string? ISBN { get; set; } = null;
    public IEnumerable<string> Genres { get; set; } = new List<string>();
    public string Illustrator { get; set; }
    public List<string> Authors { get; set; } = new List<string>();

    public BookDTO(Book book)
    {
        Id = book.Id;
        Title = book.Title;
        PublicationYear = book.PublicationYear;
        ISBN = book.ISBN;
        Genres = book.Genres
            .Select(g => g.Name)
            .ToList();
        Illustrator = book.Illustrator.GetFullName();
        Authors = book.Authors
            .Select(a => a.GetFullName())
            .ToList();
    }
}