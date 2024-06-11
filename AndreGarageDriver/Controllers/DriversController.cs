using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreGarageDriver.Data;
using Models;
using Models.DTO;
using AndreGarageAdress.Integration.Interfaces;

namespace AndreGarageDriver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly AndreGarageDriverContext _context;
        private readonly IAdressIntegration _adressIntegration;

        public DriversController(AndreGarageDriverContext context,IAdressIntegration adressIntegration)
        {
            _context = context;
            _adressIntegration = adressIntegration;
        }

        // GET: api/Drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDriver()
        {
          if (_context.Driver == null)
          {
              return NotFound();
          }
            return await _context.Driver.Include(c => c.CNH).Include(d=> d.CNH.Category).Include(a => a.Adress).ToListAsync();
        }

        // GET: api/Drivers/5
        [HttpGet("{cnh}")]
        public async Task<ActionResult<Driver>> GetDriver(string cnh)
        {
          if (_context.Driver == null)
          {
              return NotFound();
          }
            var driver = await _context.Driver.Include(c => c.CNH).Include(d => d.CNH.Category).Include(a => a.Adress).SingleOrDefaultAsync(d => d.CNH.Cnh == cnh );

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        // PUT: api/Drivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver(string id, Driver driver)
        {
            if (id != driver.Document)
            {
                return BadRequest();
            }

            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        // POST: api/Drivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Driver>> PostDriver(DriverDTO dto)
        {
            var adress = await _adressIntegration.GetAdress(dto.Adress.ZipCode);
            Adress adr = new Adress(adress);
            adr.Complement = dto.Adress.Complement;
            adr.Number = dto.Adress.Number;
            CNH cnh = new CNH(dto.cnhDTO);
            var category = await _context.Category.FindAsync(dto.cnhDTO.CategoryId);
            cnh.Category = category;
            Driver driver = new Driver(dto,adr,cnh);
            _context.Driver.Add(driver);          
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DriverExists(driver.Document))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDriver", new { id = driver.Document }, driver);
        }

        // DELETE: api/Drivers/5
        [HttpDelete("{cnh}")]
        public async Task<IActionResult> DeleteDriver(string cnh)
        {
            if (_context.Driver == null)
            {
                return NotFound();
            }
            var driver = await _context.Driver.SingleOrDefaultAsync(d => d.CNH.Cnh == cnh);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Driver.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverExists(string id)
        {
            return (_context.Driver?.Any(e => e.Document == id)).GetValueOrDefault();
        }
    }
}
