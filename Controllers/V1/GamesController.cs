using System;
using System.Linq;
using System.Threading.Tasks;
using CatalogoDeJogos.Core.Entities;
using CatalogoDeJogos.Models.InputModels;
using CatalogoDeJogos.Models.ViewModels;
using CatalogoDeJogos.Persistence;
using CatalogoDeJogos.Services;
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


        [HttpGet]
        public IActionResult GetGames()
        {
            var allGames = _dbContext.Games.Where(g => g.Active).ToList();
            
            var allGamesView = allGames
                .Select(g => new GameView(g.Id, g.Name, g.Publisher, g.Price));
            
            return Ok(allGamesView);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetGameById(Guid id)
        {   
            var game = _dbContext.Games.SingleOrDefault(g => g.Id == id);

            if(game == null || !game.Active)
                return NotFound();
            
            var gameView = new GameView(game.Id, game.Name, game.Publisher, game.Price);
            return Ok(gameView);
        }
        
        [HttpPost]
        public IActionResult PostGame([FromBody] CreateGame inputModel)
        {   
            var gameService = new GameService(_dbContext);
            var resultOfGameService = gameService.CheckIfGameIsAlreadyRegistered(inputModel);

            if(!resultOfGameService)
            {
                var guid = gameService.GetGuidOfGameAlreadyRegistered(inputModel.Name, inputModel.Publisher);
                return BadRequest($"This game is already registered with Id: {guid}");
            }
            
            var game = new Game(inputModel.Name, inputModel.Publisher, inputModel.Price);

            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetGameById), new {id = game.Id}, inputModel);
        }

        [HttpPut("{id:guid}")]
        public IActionResult PutGame(Guid id, [FromBody] UpdateGame inputModel)
        {
            var game = _dbContext.Games.SingleOrDefault(g => g.Id == id);

            if(game == null || !game.Active)
                return NotFound();
            
            game.UpdateGame(inputModel.Name, inputModel.Publisher, inputModel.Price);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:guid}/price/{price:double}")]
        public IActionResult PatchGame(Guid id, double price)
        {
            if(price < 1 || price > 1000)
                return BadRequest("Price must be between R$ 1.00 and R$ 1,000.00");
            
            var game = _dbContext.Games.SingleOrDefault(g => g.Id == id);

            if(game == null || !game.Active)
                return NotFound();
            
            game.UpdatePrice(price);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteGame(Guid id)
        {
            var game = _dbContext.Games.SingleOrDefault(g => g.Id == id);

            if(game == null || !game.Active)
                return NotFound();
            
            game.Deactivate();
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}