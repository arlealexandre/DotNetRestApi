using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsByIsbnAsync(string isbn)
    {
        if (string.IsNullOrEmpty(isbn)) return false;
        return await _context.Books.AnyAsync(b => b.ISBN == isbn);
    }

    public async Task<Book> CreateAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<bool> IsDuplicateAsync(string title, ushort year, IEnumerable<int> authorIds)
    {
        var potentialDuplicates = await _context.Books
            .Where(b => b.Title == title && b.PublicationYear == year)
            .Include(b => b.Authors)
            .ToListAsync();

        return potentialDuplicates.Any(b => 
            b.Authors.Select(a => a.Id).OrderBy(id => id)
            .SequenceEqual(authorIds.OrderBy(id => id))
        );
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books
            .Include(b => b.Illustrator)
            .Include(b => b.Authors)
            .ToListAsync();
    }
}