namespace LibraryManagementSystem.Tests;

public class BookValidationUnitTests
{

    private Book CreateValidBook()
    {
        return new Book
        {
            Title = "Test",
            PublicationYear = 2020,
            ISBN = "1234567890123",
            IllustratorId = 5,
            Illustrator = new Illustrator { FirstName = "John", LastName = "Doe" },
            Authors = new List<Author> { new Author { FirstName = "Stephen", LastName = "King" } },
            Genres = new List<Genre> { new Genre { Name = "Action" } }
        };
    }

    [Fact]
    public void Validate_ShouldNotThrowAnException_WhenBookIsValid()
    {
        // Arrange
        var book = CreateValidBook();

        // Act
        var exception = Record.Exception(() => book.Validate());

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(1449)]
    [InlineData(1000)]
    [InlineData(0)]
    public void Validate_ShouldThrowAnException_WhenPublicationYearIsTooOld(ushort invalidPublicationYear)
    {
        // Arrange
        var book = CreateValidBook();
        book.PublicationYear = invalidPublicationYear;

        // Act
        Action action = () => book.Validate();

        // Assert
        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void Validate_ShouldThrowAnException_WhenPublicationYearIsInTheFuture()
    {
        // Arrange
        var book = CreateValidBook();
        book.PublicationYear = (ushort) (DateTime.Now.Year + 1);

        // Act
        Action action = () => book.Validate();

        // Assert
        Assert.Throws<DomainException>(action);
    }

    [Theory]
    [InlineData(1450)]
    [InlineData(2000)]
    [InlineData(2002)]
    public void Validate_ShouldNotThrowAnException_WhenPublicationYearIsInRange(ushort validPublicationYear)
    {
        // Arrange
        var book = CreateValidBook();
        book.PublicationYear = validPublicationYear;

        // Act
        var exception = Record.Exception(() => book.Validate());

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Validate_ShouldNotThrowAnException_WhenPublicationYearIsCurrentYear()
    {
        // Arrange
        var book = CreateValidBook();
        book.PublicationYear = (ushort) DateTime.Now.Year;

        // Act
        var exception = Record.Exception(() => book.Validate());

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Validate_ShouldThrowAnException_WhenTitleIsEmpty()
    {
        // Arrange
        var book = CreateValidBook();
        book.Title = string.Empty;

        // Act
        Action action = () => book.Validate();

        // Assert
        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void Validate_ShouldThrowAnException_WhenNoGenreIsPassed()
    {
        // Arrange
        var book = CreateValidBook();
        book.Genres = new List<Genre>();

        // Act
        Action action = () => book.Validate();

        // Assert
        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void Validate_ShouldThrowAnException_WhenNoAuthorIsPassed()
    {
        // Arrange
        var book = CreateValidBook();
        book.Authors = new List<Author>();

        // Act
        Action action = () => book.Validate();

        // Assert
        Assert.Throws<DomainException>(action);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("123")]
    [InlineData("123123123")]
    [InlineData("1231aet23123")]
    [InlineData("aertyuipojhg")]
    [InlineData("12345678910121214152")]
    public void Validate_ShouldThrowAnException_WhenIsbnIsInvalid(string? isbn)
    {
        // Arrange
        var book = CreateValidBook();
        book.PublicationYear = 1990; // > 1970
        book.ISBN = isbn;

        // Act
        Action action = () => book.Validate();

        // Assert
        Assert.Throws<DomainException>(action);
    }

    [Theory]
    [InlineData(1450, null)]
    [InlineData(1970, "1234567890123")]
    [InlineData(2026, "9782266208871")]
    public void Validate_ShouldNotThrowAnException_WhenIsbnIsValid(ushort publicationYear, string? isbn)
    {
        // Arrange
        var book = CreateValidBook();
        book.PublicationYear = publicationYear;
        book.ISBN = isbn;

        // Act
        var exception = Record.Exception(() => book.Validate());

        // Assert
        Assert.Null(exception);
    }
}
