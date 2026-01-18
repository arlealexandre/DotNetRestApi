using LibraryManagementSystem.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController : ControllerBase
{
    private readonly ListGenresUseCase _listGenres;

    public GenresController(
        ListGenresUseCase listGenres
    )
    {
        _listGenres = listGenres;
    }

    [HttpGet]
    public async Task<IActionResult> ListGenres()
    {
        try
        {
            var result = await _listGenres.ExecuteAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { errorMessage = e.Message });
        }
    }
}