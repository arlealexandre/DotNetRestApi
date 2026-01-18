namespace LibraryManagementSystem.Application.DTOs;

public class IllustratorDTO
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public IllustratorDTO(
        Illustrator illustrator
    )
    {
        Id = illustrator.Id;
        FullName = illustrator.GetFullName();
    }
}