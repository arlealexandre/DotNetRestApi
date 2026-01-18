namespace LibraryManagementSystem.Application.DTOs;

public class ListGenresResponseDTO
{
    public List<GenreDTO> Genres { get; set; } = new();
}