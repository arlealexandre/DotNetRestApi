using System.ComponentModel.DataAnnotations;

public abstract class Person
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    protected Person() { }

    public string GetFullName() => $"{FirstName} {LastName}";
}