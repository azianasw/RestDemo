using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestDemo.Data;
using RestDemo.Models;

namespace RestDemo.Controllers
{
    [Route("api/tarifAirTangki")]
    [ApiController]
    public class TarifAirTangkisController : ControllerBase
    {
        private readonly MySqlDbContext _context;

        public TarifAirTangkisController(MySqlDbContext context)
        {
            _context = context;
        }

        // GET: api/TarifAirTangkis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarifAirTangki>>> GetTarifAirTangki(string kodeTarif = "", string namaTarif = "")
        {
            List<TarifAirTangki> tats = await _context.TarifAirTangki.Include(_ => _.Kategori).ToListAsync();
            IQueryable<TarifAirTangki> query = tats.AsQueryable();

            if (!string.IsNullOrEmpty(kodeTarif))
            {
                query = from a in query
                        where a.Kategori.KategoriTarif.ToLower().Contains(kodeTarif.ToLower())
                        select a;
            }

            if (!string.IsNullOrEmpty(namaTarif))
            {
                query = from a in query
                        where a.Kategori.NamaTarif.ToLower().Contains(namaTarif.ToLower())
                        select a;
            }

            return query.ToList();
        }

        // GET: api/TarifAirTangkis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarifAirTangki>> GetTarifAirTangki(long id)
        {
            var tarifAirTangki = await _context.TarifAirTangki.FindAsync(id);

            if (tarifAirTangki == null)
            {
                return NotFound();
            }

            await _context.Entry(tarifAirTangki).Reference(_ => _.Kategori).LoadAsync();

            return tarifAirTangki;
        }

        // PUT: api/TarifAirTangkis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarifAirTangki(long id, TarifAirTangki tarifAirTangki)
        {
            if (id != tarifAirTangki.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarifAirTangki).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarifAirTangkiExists(id))
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

        // POST: api/TarifAirTangkis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TarifAirTangki>> PostTarifAirTangki(TarifAirTangki tarifAirTangki)
        {
            _context.TarifAirTangki.Add(tarifAirTangki);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarifAirTangki", new { id = tarifAirTangki.Id }, tarifAirTangki);
        }

        // DELETE: api/TarifAirTangkis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TarifAirTangki>> DeleteTarifAirTangki(long id)
        {
            var tarifAirTangki = await _context.TarifAirTangki.FindAsync(id);
            if (tarifAirTangki == null)
            {
                return NotFound();
            }

            _context.TarifAirTangki.Remove(tarifAirTangki);
            await _context.SaveChangesAsync();

            return tarifAirTangki;
        }

        private bool TarifAirTangkiExists(long id)
        {
            return _context.TarifAirTangki.Any(e => e.Id == id);
        }
    }
}
