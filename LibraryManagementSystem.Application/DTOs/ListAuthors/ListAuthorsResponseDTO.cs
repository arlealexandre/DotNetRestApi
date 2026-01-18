namespace LibraryManagementSystem.Application.DTOs;

public class ListAuthorsResponseDTO
{
    public List<AuthorDTO> Authors { get; set; } = new();
}