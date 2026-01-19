namespace LibraryManagementSystem.Application.DTOs;

public class GenreDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public GenreDTO(
        Genre genre
    )
    {
        Id = genre.Id;
        Name = genre.Name;
    }
}