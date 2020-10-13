using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            return await _context.Quotes.ToListAsync();
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(int id)
        {
            var quote = await _context.Quotes.FindAsync(id);

            if (quote == null)
            {
                return NotFound();
            }

            return quote;
        }

        // PUT: api/Quotes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuote(int id, Quote quote)
        {
            if (id != quote.Id)
            {
                return BadRequest();
            }

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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote(Quote quote)
        {
            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuote", new { id = quote.Id }, quote);
        }

        [HttpGet("{id}/tags")]
        public async Task<ActionResult<IEnumerable<Tag>>> GetQuoteTags(int id)
        {

            // IList<QuoteTag> quoteTags = await _context.QuoteTags.Where(item => item.QuoteId == id)
            //    .Include(item => item.Tag)
            //    .ToListAsync();
            //IList<Tag> result = new List<Tag>();
            //foreach (var item in quoteTags)
            //{
            //    result.Add(item.Tag);
            //}
            var quote =  await _context.Quotes.Where(q => q.Id == id)
                    .Include(s => s.QuoteTags)
                    .ThenInclude(tag => tag.Tag).AsNoTracking().SingleOrDefaultAsync();

            if (quote == null)
            {
                return NotFound();
            }

            return quote.QuoteTags.Select(tag => tag.Tag).ToList();
        }

        [HttpPost("{id}/tags")]
        public async Task<ActionResult<Quote>> PostTags(int id, [FromBody] IEnumerable<int> tagIds)
        {
            IList<QuoteTag> quoteTags = new List<QuoteTag>();
            foreach (var item in tagIds)
            {
                QuoteTag newQuote = new QuoteTag
                {
                    QuoteId = id,
                    TagId = item
                };
                quoteTags.Add(newQuote);
            }
            _context.QuoteTags.AddRange(quoteTags);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTags", quoteTags);
        }

        // DELETE: api/Quotes/5/tags/1
        [HttpDelete("{quoteId}/tags/{quoteTagId}")]
        public async Task<ActionResult<QuoteTag>> DeleteQuote(int quoteId, int tagId)
        {
            var quoteTag = await _context.QuoteTags.Where(x => x.QuoteId == quoteId && x.TagId == tagId).SingleOrDefaultAsync();
            if (quoteTag == null)
            {
                return NotFound();
            }

            _context.QuoteTags.Remove(quoteTag);
            await _context.SaveChangesAsync();

            return quoteTag;
        }

        // DELETE: api/Quotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quote>> DeleteQuote(int id)
        {
            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }

            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();

            return quote;
        }

        private bool QuoteExists(int id)
        {
            return _context.Quotes.Any(e => e.Id == id);
        }
    }
}
