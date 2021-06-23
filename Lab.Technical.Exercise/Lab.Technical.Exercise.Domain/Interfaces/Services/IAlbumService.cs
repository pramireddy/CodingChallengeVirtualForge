using Lab.Technical.Exercise.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lab.Technical.Exercise.Domain.Interfaces.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<EntityModels.Album>> GetAlbumsAsync();

        Task<IEnumerable<EntityModels.Album>> GetByWhereAsync(Expression<Func<EntityModels.Album, bool>> predicate);

        Task<EntityModels.Album> FirstOrDefaultAsync(Expression<Func<EntityModels.Album, bool>> predicate);

        Task CreateAlbumAsync(CreateAlbumRequest createAlbumRequest);

        Task UpdateAlbumAsync(int albumId,UpdateAlbumRequest updateAlbumRequest);

        Task DeleteAlbumAsync(int albumId);

        AlbumFormOptionsData GetAlbumFormOptionsData();
    }
}