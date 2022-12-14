using AutoMapper;
using RestaurantAPI.DTOs;
using RestaurantAPI.Models;

namespace RestaurantAPI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, EmployeeOrderReadDto>();
            CreateMap<Order, CustomerOrderReadDto>();
            // CreateMap<DTOs.OrderCreateDto, Order>();
            // CreateMap<DTOs.OrderUpdateDto, Order>();
        }
    }
}