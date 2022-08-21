using AutoMapper;
using MudMyFavoriteApp.Data;

namespace MudMyFavoriteApp.Shared.Mapping
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameEntry, Game>();
        }
    }
}
