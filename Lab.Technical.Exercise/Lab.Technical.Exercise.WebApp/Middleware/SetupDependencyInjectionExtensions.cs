using Lab.Technical.Exercise.Domain.Interfaces.Repositories;
using Lab.Technical.Exercise.Domain.Interfaces.Services;
using Lab.Technical.Exercise.Domain.Services;
using Lab.Technical.Exercise.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab.Technical.Exercise.WebApp.Middleware
{
    public static class SetupDependencyInjectionExtensions
    {
        public static void SetupDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<ILabelRepository, LabelRepository>();
            services.AddScoped<IAlbumService, AlbumService>();
        }
    }
}