using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Models;

namespace LibraryManagementSystem.Application.UseCases;

public class ListBooksUseCase
{
    private readonly IBookRepository _repository;

    public ListBooksUseCase(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListBooksResponseDTO> ExecuteAsync(int? authorId, BookSortByCriteria sortBy)
    {
        var books = await _repository.GetAllAsync(authorId, sortBy);

        var response = new ListBooksResponseDTO
        {
            Books = books.Select(b => new BookDTO(b)).ToList()
        };

        return response;
    }
}