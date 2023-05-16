using HenPenApi.Data;
using HenPenApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HenPenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HenController : ControllerBase
    {
        private readonly DataContext _context;

        public HenController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hen>>> GetHens()
        {
            return Ok(await _context.Hens.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Hen>>> CreateHen(Hen hen)
        {
            _context.Hens.Add(hen);
            await _context.SaveChangesAsync();
            return Ok(await _context.Hens.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Hen>>> UpdateHen(Hen hen)
        {
            var dbHen = await _context.Hens.FindAsync(hen.HenId);
            if (dbHen == null)
            
                return BadRequest("Hen not found");
            
                dbHen.HenName = hen.HenName;
                dbHen.Description = hen.Description;
                dbHen.DOB = hen.DOB;
                dbHen.Weight = hen.Weight;
                dbHen.EggColor = hen.EggColor;
                dbHen.WklyEggAvg = hen.WklyEggAvg;
                dbHen.HealthIssue = hen.HealthIssue;
                dbHen.Medications = hen.Medications;
                dbHen.Notes = hen.Notes;
                dbHen.Breed = hen.Breed;


            await _context.SaveChangesAsync();
            return Ok(await _context.Hens.ToListAsync());                        
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Hen>>> DeleteHen(int id)
        {
            var dbHen = await _context.Hens.FindAsync(id);
            if (dbHen == null)

                return BadRequest("Hen not found");
            _context.Hens.Remove(dbHen);
            await _context.SaveChangesAsync();

            return Ok(await _context.Hens.ToListAsync());
        }
    }
}

    
