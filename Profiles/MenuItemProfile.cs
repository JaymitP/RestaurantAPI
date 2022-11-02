using AutoMapper;
using RestaurantAPI.Models;

namespace RestaurantAPI.Profiles
{
    public class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            CreateMap<MenuItemCreateDto, MenuItem>();
            CreateMap<MenuItem, MenuItemReadDto>();
        }
    }
}