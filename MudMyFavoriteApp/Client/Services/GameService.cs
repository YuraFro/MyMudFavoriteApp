using MudMyFavoriteApp.Shared;
using System.Net.Http.Json;

namespace MudMyFavoriteApp.Client.Services
{
    public class GameServiceClient : IGameServiceClient
    {
        private readonly HttpClient _htpp;

        public GameServiceClient(HttpClient htpp)
        {
            _htpp = htpp;
        }

        public List<Game> Games { get; set; } = new List<Game>();
        public List<GameStudio> GameStudios { get; set; } = new List<GameStudio>();

        public async Task GetGames()
        {
            var result = await _htpp.GetFromJsonAsync<List<Game>>("api/game");
            if (result != null)
            {
                Games = result;
            }
        }

        public async Task<Game> GetSingleGame(long id)
        {
            var result = await _htpp.GetFromJsonAsync<Game>($"api/game/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Game not found");
        }

        public async Task GetGameStudios()
        {
            var result = await _htpp.GetFromJsonAsync<List<GameStudio>>("api/gameStudios");
            if (result != null)
            {
                GameStudios = result;
            }
        }
    }
}
