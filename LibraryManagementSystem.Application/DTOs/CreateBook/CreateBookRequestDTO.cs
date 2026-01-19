namespace LibraryManagementSystem.Application.DTOs;

public class CreateBookRequestDTO
{
    public required string Title { get; set; }
    public required ushort PublicationYear { get; set; }
    public string? ISBN { get; set; }
    public required IEnumerable<int> GenreIds { get; set; } = new List<int>();
    public required IEnumerable<int> AuthorIds { get; set; } = new List<int>();
    public required int IllustratorId { get; set; }
}