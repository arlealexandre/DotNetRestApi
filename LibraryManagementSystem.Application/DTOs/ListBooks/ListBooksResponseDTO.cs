namespace LibraryManagementSystem.Application.DTOs;

public class ListBooksResponseDTO
{
    public List<BookDTO> Books { get; set; } = new();
}