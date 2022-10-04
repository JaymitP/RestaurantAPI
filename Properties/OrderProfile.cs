using AutoMapper;
using ResterauntAPI.DTOs;
using ResterauntAPI.Models;

namespace ResterauntAPI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, EmployeeOrderReadDto>();
            // CreateMap<DTOs.OrderCreateDto, Order>();
            // CreateMap<DTOs.OrderUpdateDto, Order>();
        }
    }
}