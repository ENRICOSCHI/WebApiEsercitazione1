using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEsercitazione1.Data;
using WebApiEsercitazione1.Models;

namespace WebApiEsercitazione1.Controllers
{
    public class libroController: ControllerBase
    {

        private readonly LbroDbContext _context;

        public libroController(LbroDbContext context)
        {
            _context = context;
        }

        //Get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<libro>>> Getlibri()
        {
            if(_context.libri == null)
                return NotFound();
            return await _context.libri.ToListAsync();
        }

        //post 
        [HttpPost]
        public async Task<ActionResult<libro>>Post(libro lb)
        {
            _context.libri.Add(lb);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLibro", new { matr = lb.codice },lb);
        }

        //put 
        [HttpPut("{cod}")]
        public async Task<ActionResult> Put(string cod, libro lb)
        {
            if(cod != lb.codice.ToString())
            {
                return BadRequest();
            }
            _context.Entry(lb).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //delete
        [HttpDelete]
        public async Task<ActionResult> Delete(string cod)
        {
            libro libri = await _context.libri.FindAsync(cod);
            if(libri == null)
                return NotFound();
            _context.libri.Remove(libri);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
