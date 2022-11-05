using AutoMapper;
using RestaurantAPI.Models;

namespace RestaurantAPI.Profiles
{
    public class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            CreateMap<MenuItem, MenuItemReadDto>();
            CreateMap<MenuItemWriteDto, MenuItem>();
            CreateMap<MenuItem, MenuItemWriteDto>();
        }
    }
}