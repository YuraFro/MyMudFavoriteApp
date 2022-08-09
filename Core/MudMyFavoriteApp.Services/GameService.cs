using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MudMyFavoriteApp.DataBaseEF;
using MudMyFavoriteApp.Shared;

namespace MudMyFavoriteApp.Services
{
    public class GameService : IGameService
    {
        private readonly IGameDbContext _gameDbContext;
        private readonly IMapper _mapper;

        public GameService(IGameDbContext gameDbContext,
            IMapper mapper) =>
            (_gameDbContext, _mapper) = (gameDbContext, mapper);

        public async Task<List<Game>> GetGames()
        {
            var games = await _gameDbContext.Games
                .ProjectTo<Game>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return games;
        }

        public async Task<List<GameStudio>> GetGameStudios()
        {
            var gameStudios = await _gameDbContext.GameStudios
                .ProjectTo<GameStudio>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return gameStudios;
        }
    }
}
