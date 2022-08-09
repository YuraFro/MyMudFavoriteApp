using AutoMapper;
using MudMyFavoriteApp.Data;
using MudMyFavoriteApp.Extensions.Mapping;

namespace MudMyFavoriteApp.Shared
{
    public class Game : IMapWith<GameEntry>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public GameStudio? GameStudio { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GameEntry, Game>()
                .ForMember(game => game.Id,
                opt => opt.MapFrom(gameEntry => gameEntry.Id))
                .ForMember(game => game.Name,
                opt => opt.MapFrom(gameEntry => gameEntry.Name))
                .ForMember(game => game.Description,
                opt => opt.MapFrom(gameEntry => gameEntry.Description));
        }
    }
}
