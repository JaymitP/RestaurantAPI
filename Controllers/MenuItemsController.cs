using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Data.Domain;
using RestaurantAPI.Models;
using Supermarket.API.Extensions;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemRepo _repository;
        private readonly IMapper _mapper;
        public MenuItemsController(IMenuItemRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        // [Authorize(Roles = "Administrator")]
        public ActionResult<ICollection<MenuItem>> GetAllOrders()
        {
            var menuItems = _repository.GetAllMenuItems();

            return Ok(_mapper.Map<ICollection<MenuItemReadDto>>(menuItems));
        }

        [HttpGet("{id}", Name = "GetMenuItemById")]
        [Authorize(Roles = "Administrator, Customer")]
        public ActionResult<Order> GetMenuItemById(int id)
        {
            var menuItem = _repository.GetMenuItemById(id);

            if (menuItem == null)
            {
                return NotFound(new { error = new { code = "404 Not Found", message = "Order not found" } });
            }

            return Ok(_mapper.Map<MenuItem>(menuItem));

        }

        [HttpPost()]
        public ActionResult<MenuItemReadDto> CreateMenuItem(MenuItemCreateDto menuItemCreateDto)
        {
            Console.WriteLine(ModelState.IsValid);
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is not valid");
                return BadRequest(ModelState.GetErrorMessages());
            }

            var menuItem = _mapper.Map<MenuItem>(menuItemCreateDto);
            _repository.CreateMenuItem(menuItem);
            _repository.SaveChanges();

            var MenuItemReadDto = _mapper.Map<MenuItemReadDto>(menuItem);

            return CreatedAtRoute(nameof(GetMenuItemById), new { Id = MenuItemReadDto.Id }, MenuItemReadDto);
        }
    }
}