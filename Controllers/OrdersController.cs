using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
        [Authorize(Roles = "Admin")]
        public ActionResult<ICollection<Order>> GetAllOrders()
        {
            var orders = _repository.GetAllOrders();

            return Ok(_mapper.Map<ICollection<Order>>(orders));
        }

        [HttpGet("{id}", Name = "GetOrdersById")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = _repository.GetOrderById(id);

            if (order == null)
            {
                return NotFound(new { error = new { code = "404 Not Found", message = "Order not found" } });
            }
            return Ok(_mapper.Map<Order>(order));

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

