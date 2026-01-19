using LibraryManagementSystem.Domain.Models;

namespace LibraryManagementSystem.Application.Interfaces;

public interface IBookRepository
{
    Task<bool> ExistsByIsbnAsync(string isbn);
    Task<Book> CreateAsync(Book book);
    Task<IEnumerable<Book>> GetAllAsync(int? authorId, BookSortByCriteria sortBy);
    Task<bool> IsDuplicateAsync(string title, ushort year, IEnumerable<int> authorIds);
}