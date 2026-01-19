using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

    public async Task<IEnumerable<Book>> GetAllAsync(int? authorId, BookSortByCriteria sortBy)
    {

        IQueryable<Book> query = _context.Books
            .Include(b => b.Illustrator)
            .Include(b => b.Authors)
            .Include(b => b.Genres);

        if (authorId.HasValue)
        {
            query = query.Where(b => b.Authors.Any(a => a.Id == authorId.Value));
        }

        query = sortBy switch
        {
            BookSortByCriteria.ID => query.OrderBy(b => b.Id),
            BookSortByCriteria.TITLE => query.OrderBy(b => b.Title),
            BookSortByCriteria.PUBLICATION_YEAR => query.OrderBy(b => b.PublicationYear),
            BookSortByCriteria.GENRE => query.OrderBy(b => b.Genres.First().Name),
            _ => query.OrderBy(b => b.Id)
        };

        return await query.ToListAsync();
    }
}