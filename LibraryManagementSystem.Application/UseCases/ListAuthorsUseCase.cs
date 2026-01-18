using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Interfaces;

namespace LibraryManagementSystem.Application.UseCases;

public class ListAuthorsUseCase
{
    private readonly IAuthorRepository _repository;

    public ListAuthorsUseCase(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListAuthorsResponseDTO> ExecuteAsync()
    {
        var authors = await _repository.GetAllAsync();

        var response = new ListAuthorsResponseDTO
        {
            Authors = authors.Select(a => new AuthorDTO(a)).ToList()
        };

        return response;
    }
}