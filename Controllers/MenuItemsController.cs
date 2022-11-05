using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
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
        [Authorize(Policy = "IsEmployee")]
        public ActionResult<ICollection<MenuItem>> GetAllMenuItems()
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

            return Ok(_mapper.Map<MenuItemReadDto>(menuItem));

        }

        [HttpPost()]
        public ActionResult<MenuItemReadDto> CreateMenuItem(MenuItemWriteDto menuItemWriteDto)
        {
            var menuItem = _mapper.Map<MenuItem>(menuItemWriteDto);
            _repository.CreateMenuItem(menuItem);
            _repository.SaveChanges();

            var menuItemReadDto = _mapper.Map<MenuItemReadDto>(menuItem);

            return CreatedAtRoute(nameof(GetMenuItemById), new { Id = menuItemReadDto.Id }, menuItemReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMenuItem(int id, MenuItemWriteDto menuItemWriteDto)
        {
            var menuItem = _repository.GetMenuItemById(id);

            if (menuItem == null)
            {
                return NotFound(new { error = new { code = "404 Notz     Found", message = "Order not found" } });
            }

            _mapper.Map(menuItemWriteDto, menuItem);
            _repository.UpdateMenuItem(menuItem);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")] // Endpoint for PATCH requests
        public ActionResult PartialMenuItemUpdate(int id, JsonPatchDocument<MenuItemWriteDto> patchDoc)
        {
            var menuItem = _repository.GetMenuItemById(id);
            if (menuItem == null)
            {
                return NotFound(new { error = new { code = "404 Not Found", message = "Order not found" } });
            }

            var resourceToPatch = _mapper.Map<MenuItemWriteDto>(menuItem);

            patchDoc.ApplyTo(resourceToPatch, ModelState);

            if (!TryValidateModel(resourceToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(resourceToPatch, menuItem);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMenuItem(int id)
        {
            var menuItem = _repository.GetMenuItemById(id);

            if (menuItem == null)
            {
                return NotFound(new { error = new { code = "404 Not Found", message = "Order not found" } });
            }

            _repository.DeleteMenuItem(menuItem);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}