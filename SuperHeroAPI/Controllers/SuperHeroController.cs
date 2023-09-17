using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            try
            {
                return Ok(await _context.SuperHeroes.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            try
            {
                _context.SuperHeroes.Add(hero);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Internal Error");
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero)
        {
            try
            {
                var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);
                if (dbHero == null)
                    return NotFound();

                dbHero.Name = hero.Name;
                dbHero.FirstName = hero.FirstName;
                dbHero.LastName = hero.LastName;
                dbHero.Place = hero.Place;

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Internal Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            try
            {
                var dbHero = await _context.SuperHeroes.FindAsync(id);
                if (dbHero == null)
                    return NotFound();

                _context.SuperHeroes.Remove(dbHero);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Internal Error");
            }
        }
    }
}
