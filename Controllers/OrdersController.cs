using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ResterauntAPI.Data;
using ResterauntAPI.Models;
using Microsoft.AspNetCore.Authorization;


// Controller is used to handle HTTP requests and responses. Also accesses the repository.
namespace ResterauntAPI.Controllers
{

    //Route matches URI to each method in the controller class, the [] attribute is substituted with class name during runtime
    [Route("api/orders")]
    //Provide default API behavior
    [ApiController]

    // Implements ControllerBase since view support is not needed, otherwise use Controller interface
    public class OrdersController : ControllerBase
    {

        private readonly IOrdersRepo _repository;
        // Auto Mapper is used to map the DTO to the model or vice versa
        private readonly IMapper _mapper;

        //Dependency injection -> recieves an instance of the repo interface and AutoMapper instance (to the controller) when the interface is requested
        public OrdersController(IOrdersRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet] // Endpoint for GET requests
        // [Authorize(Roles = "Admin, Waiter")]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            var orders = _repository.GetAllOrders();

            // Map the Orders model to an IEnumerable of Read DTOs
            // Ok is a helper method that returns a 200 OK status code
            return Ok(_mapper.Map<IEnumerable<Order>>(orders));
        }

        // Endpoint for GET requests with an ID
        // Endpoint is named so the URI can be referenced in the POST request
        [HttpGet("{id}", Name = "GetOrdersById")]
        public ActionResult<Order> GetOrderById(int id)
        {

            var order = _repository.GetOrderById(id);
            if (order == null)
            {
                // NotFound is a helper method that returns a 404 Not Found status code
                return NotFound(new { error = new { code = "404 Not Found", message = "Order not found" } });
            }
            // Map the Orders model to the Read DTO
            return Ok(_mapper.Map<Order>(order));

        }
    }
}

