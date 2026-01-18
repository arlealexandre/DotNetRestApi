using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Illustrator> Illustrators { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Person inheritance using Table-per-Concrete-Class (TPC) approach
        modelBuilder.Entity<Person>().UseTpcMappingStrategy();

        // Book -> Illustrator (many-to-one)
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Illustrator)
            .WithMany(i => i.Books)
            .HasForeignKey(b => b.IllustratorId)
            .IsRequired();

        // Book -> Author (many-to-many)
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity("WrittenBy");

        // Book -> Genre (many-to-many)
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity("CategorizedAs");

        // Genre name is unique
        modelBuilder.Entity<Genre>()
            .HasIndex(b => b.Name)
            .IsUnique();

        // ISBN (Book) is unique
        modelBuilder.Entity<Book>()
            .HasIndex(b => b.ISBN)
            .IsUnique();

        // Init. of Author data
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, FirstName = "Stephen", LastName = "King" },
            new Author { Id = 2, FirstName = "Marguerite", LastName = "Duras" },
            new Author { Id = 3, FirstName = "Isaac", LastName = "Asimov" }
        );

        // Init. of Illustrator data
        modelBuilder.Entity<Illustrator>().HasData(
            new Illustrator { Id = 4, FirstName = "Norman", LastName = "Rockwell" },
            new Illustrator { Id = 5, FirstName = "Gustave", LastName = "Doré" },
            new Illustrator { Id = 6, FirstName = "Beya", LastName = "Rebaï" }
        );

        // Init. of Genre data
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Action" },
            new Genre { Id = 2, Name = "Comedy" },
            new Genre { Id = 3, Name = "Drama" },
            new Genre { Id = 4, Name = "Horror" },
            new Genre { Id = 5, Name = "Science-Fiction" }
        );
    }

}