using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Interfaces;

namespace LibraryManagementSystem.Application.UseCases;

public class CreateBookUseCase
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IIllustratorRepository _illustratorRepository;
    private readonly IGenreRepository _genreRepository;

    public CreateBookUseCase(
        IBookRepository bookRepository,
        IAuthorRepository authorRepository,
        IIllustratorRepository illustratorRepository,
        IGenreRepository genreRepository
    )
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _illustratorRepository = illustratorRepository;
        _genreRepository = genreRepository;
    }

    public async Task<CreateBookResponseDTO> ExecuteAsync(CreateBookRequestDTO bookDto)
    {
        if (!string.IsNullOrEmpty(bookDto.ISBN) && await _bookRepository.ExistsByIsbnAsync(bookDto.ISBN))
        {
            throw new Exception("A book with this ISBN already exists.");
        }

        if (await _bookRepository.IsDuplicateAsync(bookDto.Title, bookDto.PublicationYear, bookDto.AuthorIds))
        {
            throw new Exception("A book with the same title, the same publication year and the same authors already exists.");
        }

        var illustrator = await _illustratorRepository.GetByIdAsync(bookDto.IllustratorId)
            ?? throw new Exception($"The specified illustrator with ID {bookDto.IllustratorId} does not exist.");

        var authors = new List<Author>();
        foreach (var id in bookDto.AuthorIds)
        {
            var author = await _authorRepository.GetByIdAsync(id)
                ?? throw new Exception($"The author with ID {id} does not exist.");
            authors.Add(author);
        }

        var genres = new List<Genre>();
        foreach (var id in bookDto.GenreIds)
        {
            var genre = await _genreRepository.GetByIdAsync(id)
                ?? throw new Exception($"The genre with ID {id} does not exist.");
            genres.Add(genre);
        }

        var book = new Book
        {
            Title = bookDto.Title,
            PublicationYear = bookDto.PublicationYear,
            ISBN = bookDto.ISBN,
            IllustratorId = illustrator.Id,
            Illustrator = illustrator,
            Authors = authors,
            Genres = genres
        };

        try { book.Validate(); } catch (DomainException e) { throw new Exception(e.Message); }

        var createdBook = await _bookRepository.CreateAsync(book);

        var response = new CreateBookResponseDTO
        {
            Book = new BookDTO(createdBook)
        };

        return response;
    }
}