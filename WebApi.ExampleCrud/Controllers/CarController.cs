using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ExampleCrud.Model;

namespace WebApi.ExampleCrud.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TarjetaCredito
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAll()
        {
            return await _context.Cars.ToListAsync();
        }

        [HttpGet("Get/{carId}")]
        public async Task<IActionResult> Get(int carId)
        {
            var response = await _context.Cars.FindAsync(carId);
            if (response == null)
            {
                return BadRequest("Not data found.");
            }

            return Ok(response);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] Car car)
        {
            try
            {
                if (car == null)
                    return BadRequest("Invalid data object.");
                var response = _context.Cars.Add(car);
                await _context.SaveChangesAsync();
                return Ok("Car has created sucessfully.");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
            

            
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Car car)
        {
            if (car == null)
                return BadRequest("Invalid data object.");
            _context.Entry(car).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok("Car has modified successfully.");
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!CarExists(car.Id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest($"Error: {e.Message}.");
                }
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return Ok("Car deleted successfully.");
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
