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
    [Route("api/kategori")]
    [ApiController]
    public class KategorisController : ControllerBase
    {
        private readonly MySqlDbContext _context;

        public KategorisController(MySqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Kategoris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategori>>> GetKategori()
        {
            return await _context.Kategori.ToListAsync();
        }

        // GET: api/Kategoris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kategori>> GetKategori(long id)
        {
            var kategori = await _context.Kategori.FindAsync(id);

            if (kategori == null)
            {
                return NotFound();
            }

            return kategori;
        }

        // PUT: api/Kategoris/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategori(long id, Kategori kategori)
        {
            if (id != kategori.Id)
            {
                return BadRequest();
            }

            _context.Entry(kategori).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategoriExists(id))
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

        // POST: api/Kategoris
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kategori>> PostKategori(Kategori kategori)
        {
            _context.Kategori.Add(kategori);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKategori", new { id = kategori.Id }, kategori);
        }

        // DELETE: api/Kategoris/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kategori>> DeleteKategori(long id)
        {
            var kategori = await _context.Kategori.FindAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }

            _context.Kategori.Remove(kategori);
            await _context.SaveChangesAsync();

            return kategori;
        }

        private bool KategoriExists(long id)
        {
            return _context.Kategori.Any(e => e.Id == id);
        }
    }
}
