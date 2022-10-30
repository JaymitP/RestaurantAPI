using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RestaurantAPI.Data;

// Controller is used to handle HTTP requests and responses. Also accesses the repository.
namespace RestaurantAPI.Controllers
{

    [Route("api/[controller]")]
    //Provide default API behavior
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IEmployeeRepo _repository;

        public LoginController(IConfiguration config, IEmployeeRepo _repo)
        {
            _config = config;
            _repository = _repo;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserLogin user)   //[FromBody]
        {
            var employee = AuthenticateUser(user);

            if (employee != null)
            {
                var tokenString = GenerateJSONWebToken(employee);
                return Ok(new { token = tokenString });
            }
            // Following HTTP authentication framework by RFC 7235
            return Unauthorized("Invalid credentials");
        }

        private object GenerateJSONWebToken(Employee employee)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, employee.EmployeeId.ToString()),
                new Claim(ClaimTypes.GivenName, employee.FirstName),
                new Claim(ClaimTypes.Surname,  employee.Surname),
                new Claim(ClaimTypes.Role, employee.Role),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                // notBefore: DateTime.Now,
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Employee? AuthenticateUser(UserLogin userLogin)
        {
            Console.WriteLine(userLogin.UserId);
            Employee? employee = _repository.GetEmployeeById(userLogin.UserId);
            if (employee != null)
            {
                if (userLogin.Password == employee.Password)
                {
                    return employee;
                }
            }

            return null;
        }
    }
}

