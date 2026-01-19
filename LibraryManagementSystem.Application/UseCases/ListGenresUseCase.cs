using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Interfaces;

namespace LibraryManagementSystem.Application.UseCases;

public class ListGenresUseCase
{
    private readonly IGenreRepository _repository;

    public ListGenresUseCase(IGenreRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListGenresResponseDTO> ExecuteAsync()
    {
        var genres = await _repository.GetAllAsync();

        var response = new ListGenresResponseDTO
        {
            Genres = genres.Select(g => new GenreDTO(g)).ToList()
        };

        return response;
    }
}