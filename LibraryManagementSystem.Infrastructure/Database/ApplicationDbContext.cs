using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}