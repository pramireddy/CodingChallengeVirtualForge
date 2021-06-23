using Lab.Technical.Exercise.Domain.EntityModels;
using Lab.Technical.Exercise.Domain.Interfaces.Repositories;
using Lab.Technical.Exercise.Infrastructure.DbContexts;

namespace Lab.Technical.Exercise.Infrastructure.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(TechnicalExerciseDbContext dbContext) : base(dbContext)
        {
        }
    }
}