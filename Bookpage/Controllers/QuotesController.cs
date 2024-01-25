using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookpage.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bookpage.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly BookpageContext _context;

        public QuotesController(BookpageContext context)
        {
            _context = context;
        }

        // GET: api/Quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
          if (_context.Quotes == null)
          {
              return NotFound();
          }
            return await _context.Quotes.ToListAsync();
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotesbyUser(int id)
        {
            if (_context.Quotes == null)
            {
                return NotFound();
            }
            Random rnd = new Random();
            return await _context.Quotes.Where(u => u.User == id).ToListAsync();
        }
        //GET: api/Quotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(int id)
        {
            if (_context.Quotes == null)
            {
                return NotFound();
            }
            var quote = await _context.Quotes.FindAsync(id);

            if (quote == null)
            {
                return NotFound();
            }

            return quote;
        }

        // PUT: api/Quotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuote(int id, QuoteDTO quoteDTO)
        {
            if (id != quoteDTO.Id)
            {
                return BadRequest();
            }
            Quote quote = new Quote();
            quote.Id = quoteDTO.Id;
            quote.Text = quoteDTO.Text;
            quote.Author = quoteDTO.Author;
            quote.User = quoteDTO.User;
            _context.Entry(quote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(id))
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

        // POST: api/Quotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote(QuoteDTO quoteDTO)
        {
          if (_context.Quotes == null)
          {
              return Problem("Entity set 'BookpageContext.Quotes'  is null.");
          }
            Quote quote = new Quote();
            quote.Id = quoteDTO.Id;
            quote.Text = quoteDTO.Text;
            quote.Author = quoteDTO.Author;
            quote.User = quoteDTO.User;
            
            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();
            return Ok(quote);
            
        }

        // DELETE: api/Quotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            if (_context.Quotes == null)
            {
                return NotFound();
            }
            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }

            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool QuoteExists(int id)
        {
            return (_context.Quotes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
