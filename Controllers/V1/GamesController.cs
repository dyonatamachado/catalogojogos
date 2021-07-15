using System;
using System.Threading.Tasks;
using CatalogoDeJogos.Models.InputModels;
using CatalogoDeJogos.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeJogos.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class GamesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetGames()
        {
            // return NoContent();
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetGameById(Guid id)
        {   
            // return NotFound();
            return Ok();
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

        [HttpDelete("{id:guid")]
        public IActionResult DeleteGame(Guid id)
        {
            // return NotFound();
            return NoContent();
        }
    }
}