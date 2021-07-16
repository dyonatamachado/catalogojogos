using System;
using System.Linq;
using System.Threading.Tasks;
using CatalogoDeJogos.Models.InputModels;
using CatalogoDeJogos.Models.ViewModels;
using CatalogoDeJogos.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeJogos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly GamesContext _dbContext;
        public GamesController(GamesContext dbContext)
        {
            _dbContext = dbContext;
        }



        public IActionResult GetGames()
        {
            // return NoContent();
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetGameById(Guid id)
        {   
            var game = _dbContext.Games.SingleOrDefault(g => g.Id == id);

            if(game == null)
                return NotFound();
            
            var gameView = new GameView(game.Id, game.Name, game.Publisher, game.Price);
            return Ok(gameView);
        }

        [HttpPost]
        public IActionResult PostGame([FromBody] CreateGame inputModel)
        {
            // return BadRequest();
            return CreatedAtAction(nameof(GetGameById), new { id = 10}, inputModel);
        }

        [HttpPut("{id:guid}")]
        public IActionResult PutGame(Guid id, [FromBody] UpdateGame inputModel)
        {
            // return NotFound();
            return NoContent();
        }

        [HttpPatch("{id:guid}/price/{price:double}")]
        public IActionResult PatchGame(Guid id, double price)
        {
            // return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteGame(Guid id)
        {
            // return NotFound();
            return NoContent();
        }
    }
}