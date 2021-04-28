using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

namespace THWebApi.Controllers
{
    [EnableCors("AllowAll")]
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {

        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(ILogger<PlayerController> logger, IPlayerRepository playerRepository)
        {
            _logger = logger;
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return _playerRepository.GetAll();
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var player = _playerRepository.Get(id);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Player> Create(Player player)
        {
            int id = _playerRepository.Add(player);
            player.Id = id;

            return CreatedAtAction(nameof(Get), new { id = player.Id }, player);
        }


    }
}
