using Lab.Technical.Exercise.DataContracts;
using Lab.Technical.Exercise.Domain.Exceptions;
using Lab.Technical.Exercise.Domain.Interfaces.Repositories;
using Lab.Technical.Exercise.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lab.Technical.Exercise.Domain.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly ILabelRepository labelRepository;
        private readonly IArtistRepository artistRepository;

        public AlbumService(IAlbumRepository albumRepository, ILabelRepository labelRepository,IArtistRepository artistRepository)
        {
            this.albumRepository = albumRepository;
            this.labelRepository = labelRepository;
            this.artistRepository = artistRepository;
        }

        public async Task CreateAlbumAsync(CreateAlbumRequest createAlbumRequest)
        {
            var albumToCreate = new EntityModels.Album
            {
                Name = createAlbumRequest.AlbumName,
                AlbumType = createAlbumRequest.AlbumType,
                ArtistId = createAlbumRequest.ArtistId,
                LabelId = createAlbumRequest.LabelId,
                Stock = new EntityModels.Stock
                {
                    Quantity = createAlbumRequest.Stock
                }
            };
            await albumRepository.CreateAsync(albumToCreate);
        }

        public async Task DeleteAlbumAsync(int albumId)
        {
            var albumToDelete = await AlbumExists(albumId);
            await albumRepository.DeleteAsync(albumToDelete);
        }

        public async Task<EntityModels.Album> FirstOrDefaultAsync(Expression<Func<EntityModels.Album, bool>> predicate)
        {
            return await albumRepository.FirstOrDefault(predicate);
        }

        public AlbumFormOptionsData GetAlbumFormOptionsData()
        {
            var artists = artistRepository.GetAll().ToList().Select(x => new Artist
            {
                Id = x.Id,
                Name = x.Name
            });

            var labels = labelRepository.GetAll().ToList().Select(x => new Label
            {
                Id = x.Id,
                Name = x.Name
            });

            return new AlbumFormOptionsData
            {
                Artists = artists,
                Labels = labels
            };
        }

        public async Task<IEnumerable<EntityModels.Album>> GetAlbumsAsync()
        {
            return await albumRepository.GetAlbumsAsync();
        }

        public async Task<IEnumerable<EntityModels.Album>> GetByWhereAsync(Expression<Func<EntityModels.Album, bool>> predicate)
        {
            return await albumRepository.GetByWhereAsync(predicate);
        }

        public async Task UpdateAlbumAsync(int albumId, UpdateAlbumRequest updateAlbumRequest)
        {
            var albumToUpdate = await AlbumExists(albumId);

            albumToUpdate = MapToAlbumEntity(albumToUpdate, updateAlbumRequest);

            await albumRepository.UpdateAsync(albumToUpdate);
        }

        private async Task<EntityModels.Album> AlbumExists(int albumId)
        {
            EntityModels.Album albumEntity = (await albumRepository.GetByWhereAsync(x => x.Id == albumId)).ToList().FirstOrDefault();

            if (albumEntity == null)
            {
                var message = $"No album found for AlbumId: {albumId}";
                throw new NotFoundException(message);
            }
            return albumEntity;
        }

        private EntityModels.Album MapToAlbumEntity(EntityModels.Album albumToUpdate, UpdateAlbumRequest updateAlbumRequest)
        {
            albumToUpdate.Name = updateAlbumRequest.AlbumName;
            albumToUpdate.AlbumType = updateAlbumRequest.AlbumType;
            albumToUpdate.ArtistId = updateAlbumRequest.ArtistId;
            albumToUpdate.LabelId = updateAlbumRequest.LabelId;
            albumToUpdate.UpdatedDate = DateTime.UtcNow;
            albumToUpdate.Stock.Quantity = updateAlbumRequest.Stock;

            return albumToUpdate;
        }
    }
}