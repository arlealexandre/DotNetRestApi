namespace LibraryManagementSystem.Application.DTOs;

public class AuthorDTO
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public AuthorDTO(
        Author author
    )
    {
        Id = author.Id;
        FullName = author.GetFullName();
    }
}