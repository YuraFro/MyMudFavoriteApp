using AutoMapper;
using MudMyFavoriteApp.Data;
using MudMyFavoriteApp.Extensions.Mapping;

namespace MudMyFavoriteApp.Shared
{
    public class GameStudio : IMapWith<GameStudioEntry>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string County { get; set; }

        public string Culture { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GameStudioEntry, GameStudio>()
                .ForMember(gameStudio => gameStudio.Id,
                opt => opt.MapFrom(gameStudioEntry => gameStudioEntry.Id))
                .ForMember(gameStudio => gameStudio.Name,
                opt => opt.MapFrom(gameStudioEntry => gameStudioEntry.Name))
                .ForMember(gameStudio => gameStudio.County,
                opt => opt.MapFrom(gameStudioEntry => gameStudioEntry.County))
                .ForMember(gameStudio => gameStudio.Culture,
                opt => opt.MapFrom(gameStudioEntry => gameStudioEntry.Culture));
        }
    }
}