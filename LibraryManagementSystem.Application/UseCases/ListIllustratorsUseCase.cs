using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Interfaces;

namespace LibraryManagementSystem.Application.UseCases;

public class ListIllustratorsUseCase
{
    private readonly IIllustratorRepository _repository;

    public ListIllustratorsUseCase(IIllustratorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListIllustratorsResponseDTO> ExecuteAsync()
    {
        var illustrators = await _repository.GetAllAsync();

        var response = new ListIllustratorsResponseDTO
        {
            Illustrators = illustrators.Select(i => new IllustratorDTO(i)).ToList()
        };

        return response;
    }
}