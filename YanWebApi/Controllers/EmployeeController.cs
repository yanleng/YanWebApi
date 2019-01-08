using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YanWebApi.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace YanWebApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly YanDBContext _context;

        public EmployeeController(YanDBContext context)
        {
            _context = context;

            if (_context.Employees.Count() == 0)
            {
                _context.Employees.Add(new Employee { FirstName = "Georges" });
                _context.SaveChanges();
            }
        }

        // GET api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // POST api/employees
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // PUT api/employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(long id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(long id)
        {
            var todoItem = await _context.Employees.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }
    }
}
