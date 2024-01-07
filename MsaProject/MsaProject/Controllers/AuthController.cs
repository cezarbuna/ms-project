using Microsoft.AspNetCore.Mvc;
using MsaProject.Dal;
using MsaProject.Domain;
using MsaProject.Services;

namespace MsaProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;
        private MsaProjectDbContext _dbContext;

        public AuthController(JwtTokenService jwtTokenService, MsaProjectDbContext dbContext)
        {
            _jwtTokenService = jwtTokenService;
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Email == loginModel.Email && x.Password == loginModel.Password);
            var owner = _dbContext.Owners.FirstOrDefault(x => x.Email == loginModel.Email && x.Password == loginModel.Password);

            string role = String.Empty;
            string token = String.Empty;
            Guid userId = Guid.Empty;

            if (customer != null && owner == null)
            {
                role = "Customer";
                userId = customer.Id;
                token = _jwtTokenService.GenerateToken(customer.Email, role);
            }
            else if (customer == null && owner != null)
            {
                role = "Owner";
                userId = owner.Id;
                token = _jwtTokenService.GenerateToken(owner.Email, role);
            }
                
            else if(customer == null && owner == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { Token = token, Role = role });
        }
    }
}
