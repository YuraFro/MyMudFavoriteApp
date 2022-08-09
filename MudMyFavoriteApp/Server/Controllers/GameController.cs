using Microsoft.AspNetCore.Mvc;
using MudMyFavoriteApp.Services;
using MudMyFavoriteApp.Shared;

namespace MudMyFavoriteApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService) =>
            _gameService = gameService;

       
        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            var games = await _gameService.GetGames();

            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetSingleGame(long id)
        {
            var games = await _gameService.GetGames();

            var game = games.FirstOrDefault(item => item.Id == id);
            
            if (game is null)
            {
                return NotFound("Sorry, no game her");
            }
            return Ok(game);
        }

        [HttpGet("gameStudio")]
        public async Task<ActionResult<List<GameStudio>>> GetGameStudios()
        {
            var gameStudios = await _gameService.GetGameStudios();

            return Ok(gameStudios);
        }
    }
}
