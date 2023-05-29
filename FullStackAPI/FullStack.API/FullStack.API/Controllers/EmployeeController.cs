using FullStack.API.Data;
using FullStack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
        private readonly IHttpClientFactory _httpClientFactory;
        public EmployeeController(
            FullStackDbContext fullStackDbContext,
            IHttpClientFactory httpClientFactory
            )
        {
            _httpClientFactory = httpClientFactory;
            _fullStackDbContext = fullStackDbContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        //public async Task<IActionResult> GetAllEmployees()
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var gitHubHttpClient = _httpClientFactory.CreateClient("github"); 
            var employee = await _fullStackDbContext.Employees.ToListAsync();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> ADdEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();
            await _fullStackDbContext.Employees.AddAsync(employeeRequest);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(employeeRequest);
        }
    }
}
