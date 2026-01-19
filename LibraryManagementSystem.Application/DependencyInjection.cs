using LibraryManagementSystem.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ListBooksUseCase>();
        services.AddScoped<CreateBookUseCase>();
        services.AddScoped<ListGenresUseCase>();
        services.AddScoped<ListAuthorsUseCase>();
        services.AddScoped<ListIllustratorsUseCase>();

        return services;
    }
}