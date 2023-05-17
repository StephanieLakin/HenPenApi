using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HenPenApi.Data;
using HenPenApi.Models;

namespace HenPenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedsController : ControllerBase
    {
        private readonly DataContext _context;

        public BreedsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Breeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breed>>> GetBreeds()
        {
          if (_context.Breeds == null)
          {
              return NotFound();
          }
            return await _context.Breeds.ToListAsync();
        }

        // GET: api/Breeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Breed>> GetBreed(int id)
        {
          if (_context.Breeds == null)
          {
              return NotFound();
          }
            var breed = await _context.Breeds.FindAsync(id);

            if (breed == null)
            {
                return NotFound();
            }

            return breed;
        }

        // PUT: api/Breeds/5      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBreed(int id, Breed breed)
        {
            if (id != breed.Id)
            {
                return BadRequest();
            }

            _context.Entry(breed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedExists(id))
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

        // POST: api/Breeds
        
        [HttpPost]
        public async Task<ActionResult<Breed>> CreateBreed(Breed breed)
        {
          if (_context.Breeds == null)
          {
              return Problem("Entity set 'DataContext.Breeds'  is null.");
          }
            _context.Breeds.Add(breed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBreed", new { id = breed.Id }, breed);
        }

        // DELETE: api/Breeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed(int id)
        {
            if (_context.Breeds == null)
            {
                return NotFound();
            }
            var breed = await _context.Breeds.FindAsync(id);
            if (breed == null)
            {
                return NotFound();
            }

            _context.Breeds.Remove(breed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreedExists(int id)
        {
            return (_context.Breeds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
