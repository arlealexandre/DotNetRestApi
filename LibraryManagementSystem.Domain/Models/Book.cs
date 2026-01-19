public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required ushort PublicationYear { get; set; }
    public string? ISBN { get; set; }
    public required IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    public required IEnumerable<Author> Authors { get; set; } = new List<Author>();
    public required int IllustratorId { get; set; }
    public required Illustrator Illustrator { get; set; }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Title))
            throw new DomainException("Title is mandatory.");

        if (Illustrator == null)
            throw new DomainException("Illustrator is mandatory");

        if (!Genres.Any())
            throw new DomainException("At least one genre is mandatory.");

        if (!Authors.Any())
            throw new DomainException("At least one author is mandatory.");

        if (Illustrator == null)
            throw new DomainException("Illustrator is mandatory");

        if (!IsPublicationYearValid())
            throw new DomainException($"The year of publication must be between 1450 and {DateTime.Now.Year}.");

        if (!IsIsbnValid())
            throw new DomainException("The ISBN is invalid. It must contain 13 digits for books published since 1970.");
    }

    private bool IsPublicationYearValid()
    {
        return PublicationYear >= 1450 && PublicationYear <= DateTime.Now.Year;
    }

    private bool IsIsbnValid()
    {
        if (PublicationYear >= 1970)
        {
            return !string.IsNullOrEmpty(ISBN) && ISBN.Length == 13 && ISBN.All(char.IsDigit);
        }

        // Before 1970, ISBN did not exist, so we can allow the value to be null and return true
        return true;
    }
}