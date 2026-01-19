using LibraryManagementSystem.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly ListAuthorsUseCase _listAuthors;

    public AuthorsController(
        ListAuthorsUseCase listAuthors
    )
    {
        _listAuthors = listAuthors;
    }

    [HttpGet]
    public async Task<IActionResult> ListAuthors()
    {
        try
        {
            var result = await _listAuthors.ExecuteAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { errorMessage = e.Message });
        }
    }
}