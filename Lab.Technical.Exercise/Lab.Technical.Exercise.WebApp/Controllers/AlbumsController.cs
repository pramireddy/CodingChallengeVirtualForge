using AutoMapper;
using Lab.Technical.Exercise.DataContracts;
using Lab.Technical.Exercise.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab.Technical.Exercise.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService albumService;
        private readonly IMapper mapper;

        public AlbumsController(IAlbumService albumService, IMapper mapper)
        {
            this.albumService = albumService;
            this.mapper = mapper;
        }

        // GET: api/<AlbumsController>
        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<Album>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Album>> Get()
        {
            var albums = await albumService.GetAlbumsAsync();

            var albumsDto = mapper.Map<IEnumerable<Album>>(albums);

            return Ok(albumsDto);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(ActionResult<Album>), StatusCodes.Status200OK)]
        public ActionResult<AlbumFormOptionsData> GetAlbumFormOptionsData()
        {
            var formSelectionData = albumService.GetAlbumFormOptionsData();

            return Ok(formSelectionData);
        }

        // GET api/<AlbumsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ActionResult<Album>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionResult<Album>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AlbumDetails>> Get(int id)
        {
            var album = (await albumService.GetByWhereAsync(x => x.Id == id)).ToList().FirstOrDefault();

            if (album == null)
            {
                return NotFound();
            }

            var albumDetails = new AlbumDetails
            {
                Id = album.Id,
                Artist = album.Artist.Name,
                Label = album.Label.Name,
                Name = album.Name,
                Stock = album.Stock.Quantity,
                Type = album.AlbumType.ToString()
            };

            return Ok(albumDetails);
        }

        // POST api/<AlbumsController>
        [HttpPost]
        [ProducesResponseType(typeof(ActionResult<Album>), StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Post([FromBody] CreateAlbumRequest createAlbumRequest)
        {
            await albumService.CreateAlbumAsync(createAlbumRequest);

            return NoContent();
        }

        // PUT api/<AlbumsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ActionResult<Album>), StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateAlbumRequest updateAlbumRequest)
        {
            await albumService.UpdateAlbumAsync(id,updateAlbumRequest);

            return NoContent();
        }

        // DELETE api/<AlbumsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ActionResult<Album>), StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            await albumService.DeleteAlbumAsync(id);

            return NoContent();
        }
    }
}