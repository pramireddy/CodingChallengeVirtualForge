using Lab.Technical.Exercise.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Technical.Exercise.Domain.Interfaces.Repositories
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<IEnumerable<Album>> GetAlbumsAsync();

        Task<IEnumerable<Album>> GetByWhereAsync(Expression<Func<Album, bool>> predicate);
    }
}
