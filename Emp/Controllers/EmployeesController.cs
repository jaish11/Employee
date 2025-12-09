using Emp.Entities;
using Emp.Infrastructure; 
using Microsoft.AspNetCore.Mvc;

namespace Emp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employeeRepository;
        public EmployeesController(IEmployee employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeRepository.GetAll();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee employee)
        {
            await _employeeRepository.Add(employee);
            return Ok(new { message = "Added" });

        }
        [HttpPut ("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
        {
            if(id != employee.Id)
            {
                return BadRequest();
            }
            await _employeeRepository.Update(employee);
            return Ok(new { message = "Updated" });

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.Delete(id);
            return Ok(new { message = "Deleted" });

        }
    }
}
