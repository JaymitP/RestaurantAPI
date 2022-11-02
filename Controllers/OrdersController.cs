using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using RestaurantAPI.DTOs;
using Supermarket.API.Extensions;
using RestaurantAPI.Data.Domain;

// Controller is used to handle HTTP requests and responses. Also accesses the repository.
namespace RestaurantAPI.Controllers
{

    [Route("api/orders")]
    [ApiController]

    public class OrdersController : ControllerBase
    {

        private readonly IOrdersRepo _repository;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult<ICollection<Order>> GetAllOrders()
        {
            var orders = _repository.GetAllOrders();

            return Ok(_mapper.Map<ICollection<Order>>(orders));
        }

        [HttpGet("{id}", Name = "GetOrdersById")]
        [Authorize(Roles = "Administrator, Customer")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = _repository.GetOrderById(id);

            if (order == null)
            {
                return NotFound(new { error = new { code = "404 Not Found", message = "Order not found" } });
            }
            var currentUser = GetCurrentUser();
            Console.WriteLine(currentUser?.Role);

            return Ok(_mapper.Map<Order>(order));

        }

        [HttpPost()]
        public ActionResult<EmployeeOrderReadDto> CreateOrder(OrderCreateDto? orderCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var order = _mapper.Map<Order>(orderCreateDto);
            _repository.CreateOrder(order);
            _repository.SaveChanges();

            // Map the order model to the Read DTO
            var EmployeeOrderReadDto = _mapper.Map<EmployeeOrderReadDto>(order);

            // CreatedAtRoute is a helper method that returns a 201 Created status code
            // The route name is used to generate the URI for the resource created -> in accordance with RESTful API design
            return CreatedAtRoute(nameof(GetOrderById), new { Id = EmployeeOrderReadDto.Id }, EmployeeOrderReadDto);
        }

        private Employee? GetCurrentUser()
        {
            var userClaims = (HttpContext.User.Identity as ClaimsIdentity)?.Claims;

            if (userClaims != null)
            {
                return new Employee
                {
                    EmployeeId = short.Parse(userClaims.First(o => o.Type == ClaimTypes.NameIdentifier).Value),
                    FirstName = userClaims.First(o => o.Type == ClaimTypes.GivenName).Value,
                    Surname = userClaims.First(o => o.Type == ClaimTypes.Surname).Value,
                    Role = userClaims.First(o => o.Type == ClaimTypes.Role).Value
                };
            }
            return null;
        }
    }
}

