using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.UseCases;
using LibraryManagementSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly ListBooksUseCase _listBooks;
    private readonly CreateBookUseCase _createBook;

    public BooksController(
        ListBooksUseCase listBooks,
        CreateBookUseCase createBook
    )
    {
        _listBooks = listBooks;
        _createBook = createBook;
    }

    [HttpGet]
    public async Task<IActionResult> ListBooks([FromQuery] int? authorId, [FromQuery] BookSortByCriteria sortBy = BookSortByCriteria.ID)
    {
        try
        {
            var result = await _listBooks.ExecuteAsync(authorId, sortBy);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { errorMessage = e.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookRequestDTO bookDto)
    {
        try
        {
            var result = await _createBook.ExecuteAsync(bookDto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { errorMessage = e.Message });
        }
    }
}