using MudMyFavoriteApp.Shared;

namespace MudMyFavoriteApp.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetGames();

        Task<List<GameStudio>> GetGameStudios();
    }
}
