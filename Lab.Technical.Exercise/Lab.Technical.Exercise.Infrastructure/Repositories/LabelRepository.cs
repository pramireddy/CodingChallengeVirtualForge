using Lab.Technical.Exercise.Domain.EntityModels;
using Lab.Technical.Exercise.Domain.Interfaces.Repositories;
using Lab.Technical.Exercise.Infrastructure.DbContexts;

namespace Lab.Technical.Exercise.Infrastructure.Repositories
{
    public class LabelRepository : Repository<Label>, ILabelRepository
    {
        public LabelRepository(TechnicalExerciseDbContext dbContext) : base(dbContext)
        {
        }
    }
}