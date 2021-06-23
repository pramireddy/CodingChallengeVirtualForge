using FluentAssertions;
using Lab.Technical.Exercise.DataContracts.Enums;
using Lab.Technical.Exercise.Domain.EntityModels;
using Lab.Technical.Exercise.Domain.Exceptions;
using Lab.Technical.Exercise.Domain.Interfaces.Repositories;
using Lab.Technical.Exercise.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Lab.Technical.Exercise.Domain.Test.Services
{
    public class AlbumServiceTest
    {
        private readonly Mock<IAlbumRepository> _mockAlbumRepository;
        private readonly Mock<IArtistRepository> _mockArtistRepository;
        private readonly Mock<ILabelRepository> _mockLabelRepository;

        public AlbumServiceTest()
        {
            _mockAlbumRepository = new Mock<IAlbumRepository>();
            _mockArtistRepository = new Mock<IArtistRepository>();
            _mockLabelRepository = new Mock<ILabelRepository>();
        }

        [Fact]
        public async Task Should_return_albums()
        {
            // Arrange
            _mockAlbumRepository.Setup(x => x.GetAlbumsAsync()).Returns(Task.FromResult(GetAlbums()));

            AlbumService albumService = new AlbumService(_mockAlbumRepository.Object, _mockLabelRepository.Object, _mockArtistRepository.Object);

            // Act
            var albums = await albumService.GetAlbumsAsync();

            // Assert
            albums.Should().NotBeEmpty();
            albums.Count().Should().Be(3);
            _mockAlbumRepository.Verify(x => x.GetAlbumsAsync(), Times.Once());
        }

        [Fact]
        public async Task Should_create_new_album()
        {
            // Arrage
            DataContracts.CreateAlbumRequest createAlbumRequest = new DataContracts.CreateAlbumRequest
            {
                AlbumName = "Test123",
                AlbumType = AlbumType.CD,
                ArtistId = 111,
                LabelId = 222,
                Stock = 200
            };
            _mockAlbumRepository.Setup(x => x.CreateAsync(It.IsAny<Album>()));
            AlbumService albumService = new AlbumService(_mockAlbumRepository.Object, _mockLabelRepository.Object, _mockArtistRepository.Object);

            // Act
            await albumService.CreateAlbumAsync(createAlbumRequest);

            // Assert
            _mockAlbumRepository.Verify(x => x.CreateAsync(It.IsAny<Album>()), Times.Once());
        }

        [Fact]
        public void Should_throw_not_found_exception_when_update_album_with_invalid_id()
        {
            // Arrage
            DataContracts.UpdateAlbumRequest updateAlbumRequest = new DataContracts.UpdateAlbumRequest
            {
                Id = 111,
                AlbumName = "Test123",
                AlbumType = AlbumType.CD,
                ArtistId = 111,
                LabelId = 222,
                Stock = 200
            };

            AlbumService albumService = new AlbumService(_mockAlbumRepository.Object, _mockLabelRepository.Object, _mockArtistRepository.Object);

            // Act
            Func<Task> action = async () => { await albumService.UpdateAlbumAsync(111, updateAlbumRequest); };

            // Assert
            action.Should().Throw<NotFoundException>();
            _mockAlbumRepository.Verify(x => x.UpdateAsync(It.IsAny<Album>()), Times.Never());
        }

        [Fact]
        public void Should_update_album_with_a_valid_id()
        {
            // Arrage
            int ablumIdToUpdate = 111;
            DataContracts.UpdateAlbumRequest updateAlbumRequest = new DataContracts.UpdateAlbumRequest
            {
                Id = ablumIdToUpdate,
                AlbumName = "Test123",
                AlbumType = AlbumType.CD,
                ArtistId = 111,
                LabelId = 222,
                Stock = 200
            };
            _mockAlbumRepository.Setup(x => x.GetByWhereAsync(It.IsAny<Expression<Func<Album, bool>>>()))
                                .Returns(Task.FromResult(GetAlbums()));

            AlbumService albumService = new AlbumService(_mockAlbumRepository.Object, _mockLabelRepository.Object, _mockArtistRepository.Object);

            // Act
            Func<Task> action = async () => { await albumService.UpdateAlbumAsync(ablumIdToUpdate, updateAlbumRequest); };

            // Assert
            action.Should().NotThrow<NotFoundException>();
            _mockAlbumRepository.Verify(x => x.UpdateAsync(It.IsAny<Album>()), Times.Once());
        }

        private IEnumerable<Album> GetAlbums()
        {
            return new List<Album>
            {
                new Album
                {
                    Id = 111,
                    Name = "Album111",
                    AlbumType = AlbumType.CD,
                    Artist = GetArtists().FirstOrDefault(x=>x.Id == 111),
                    Label = GetLabels().FirstOrDefault(x=>x.Id == 111),
                    Stock = GetStocks().FirstOrDefault(x=>x.AlbumId == 111)
                },
                new Album
                {
                    Id = 222,
                    AlbumType = AlbumType.CD,
                    Name = "Album222",
                    Artist = GetArtists().FirstOrDefault(x=>x.Id == 111),
                    Label = GetLabels().FirstOrDefault(x=>x.Id == 111),
                    Stock = GetStocks().FirstOrDefault(x=>x.AlbumId == 222)
                },
                new Album
                {
                    Id = 333,
                    Name = "Album333",
                    AlbumType = AlbumType.CD,
                    Artist = GetArtists().FirstOrDefault(x=>x.Id == 111),
                    Label = GetLabels().FirstOrDefault(x=>x.Id == 111),
                    Stock = GetStocks().FirstOrDefault(x=>x.AlbumId == 333)
                }
            };
        }

        private IEnumerable<Artist> GetArtists()
        {
            return new List<Artist>
            {
                new Artist
                {
                    Id = 111,
                    Name = "Artist111"
                },
                new Artist
                {
                    Id = 222,
                    Name = "Artist222"
                },
                new Artist
                {
                    Id = 333,
                    Name = "Artist333"
                }
            };
        }

        private IEnumerable<Label> GetLabels()
        {
            return new List<Label>
            {
                new Label
                {
                    Id = 111,
                    Name = "Label111"
                },
                new Label
                {
                    Id = 222,
                    Name = "Label222"
                },
                new Label
                {
                    Id = 333,
                    Name = "Label33"
                }
            };
        }

        private IEnumerable<Stock> GetStocks()
        {
            return new List<Stock>
            {
                new Stock{Id=11, AlbumId = 111, Quantity=100},
                new Stock{Id=12, AlbumId = 222, Quantity=200},
                new Stock{Id=13, AlbumId = 333, Quantity=300},
            };
        }
    }
}