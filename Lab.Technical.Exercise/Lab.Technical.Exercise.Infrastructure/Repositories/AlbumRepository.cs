using Lab.Technical.Exercise.Domain.EntityModels;
using Lab.Technical.Exercise.Domain.Interfaces.Repositories;
using Lab.Technical.Exercise.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lab.Technical.Exercise.Infrastructure.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(TechnicalExerciseDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            return await GetAll()
                        .Include(x => x.Artist)
                        .Include(x => x.Label)
                        .Include(x => x.Stock)
                        .OrderBy(x => x.Id)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Album>> GetByWhereAsync(Expression<Func<Album, bool>> predicate)
        {
            return await GetAll()
                        .Where(predicate)
                        .Include(x => x.Artist)
                        .Include(x => x.Label)
                        .Include(x => x.Stock)
                        .OrderBy(x => x.Id)
                        .ToListAsync();
        }
    }
}