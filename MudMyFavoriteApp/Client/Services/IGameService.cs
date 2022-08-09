using MudMyFavoriteApp.Shared;

namespace MudMyFavoriteApp.Client.Services
{
    public interface IGameServiceClient
    {
        public List<Game> Games { get; set; }

        public List<GameStudio> GameStudios { get; set; }

        Task GetGames();

        Task<Game> GetSingleGame(long id);
    }
}
