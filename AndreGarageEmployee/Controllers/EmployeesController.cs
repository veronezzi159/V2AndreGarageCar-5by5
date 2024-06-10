using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreGarageEmployee.Data;
using Models;
using Models.DTO;
using AndreGarageAdress.Integration.Interfaces;

namespace AndreGarageEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AndreGarageEmployeeContext _context;
        private readonly IAdressIntegration _adressIntegration;

        public EmployeesController(AndreGarageEmployeeContext context, IAdressIntegration adressIntegration)
        {
            _context = context;
            _adressIntegration = adressIntegration;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
          if (_context.Employee == null)
          {
              return NotFound();
          }
            return await _context.Employee.Include(e => e.Adress).Include(e => e.Position).ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
          if (_context.Employee == null)
          {
              return NotFound();
          }
            var employee = await _context.Employee.Include(e=> e.Adress).Include(e=> e.Position).FirstOrDefaultAsync(e => e.Document == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, Employee employee)
        {
            if (id != employee.Document)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeDTO dto)
        {
            var adress = await _adressIntegration.GetAdress(dto.Adress.ZipCode);
            if (adress == null)
            {
                return Problem("Adress not found.");
            }
            Adress adress1 = new Adress(adress);
            adress1.Complement = dto.Adress.Complement;
            adress1.Number = dto.Adress.Number;
            Employee employee = new Employee(dto, adress1);

            employee.Position = await _context.Position.FindAsync(dto.PositionId);

          if (employee == null)
          {
              return Problem("Entity set 'AndreGarageEmployeeContext.Employee'  is null.");
          }
            _context.Employee.Add(employee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.Document))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployee", new { id = employee.Document }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(string id)
        {
            return (_context.Employee?.Any(e => e.Document == id)).GetValueOrDefault();
        }
    }
}
