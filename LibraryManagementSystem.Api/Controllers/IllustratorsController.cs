using LibraryManagementSystem.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers;

[ApiController]
[Route("api/illustrators")]
public class IllustratorsController : ControllerBase
{
    private readonly ListIllustratorsUseCase _listIllustrators;

    public IllustratorsController(
        ListIllustratorsUseCase listIllustrators
    )
    {
        _listIllustrators = listIllustrators;
    }

    [HttpGet]
    public async Task<IActionResult> ListIllustrators()
    {
        try
        {
            var result = await _listIllustrators.ExecuteAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { errorMessage = e.Message });
        }
    }
}