using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Interfaces;

namespace LibraryManagementSystem.Application.UseCases;

public class ListBooksUseCase
{
    private readonly IBookRepository _repository;

    public ListBooksUseCase(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListBooksResponseDTO> ExecuteAsync()
    {
        var books = await _repository.GetAllAsync();

        var response = new ListBooksResponseDTO
        {
            Books = books.Select(b => new BookDTO(b)).ToList()
        };

        return response;
    }
}