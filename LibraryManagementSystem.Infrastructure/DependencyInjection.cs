using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IIllustratorRepository, IllustratorRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();

        return services;
    }
}