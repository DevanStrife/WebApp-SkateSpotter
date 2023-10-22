using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkateSpotter_MVC.Data;
using SkateSpotter_MVC.Models;

namespace SkateSpotter_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public BrandsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            // Check if the 'Brands' entity set is null, and return NotFound if it is.
            if (_context.Brands == null)
          {
              return NotFound();
          }
            // Retrieve and return a list of all brands.
            return await _context.Brands.ToListAsync();
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            // Check if the 'Brands' entity set is null, and return NotFound if it is.
            if (_context.Brands == null)
          {
              return NotFound();
          }
            // Find a brand by its ID.
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, Brand brand)
        {
            if (id != brand.Id)
            {
                // If the provided ID does not match the brand's ID, return BadRequest.
                return BadRequest();
            }
            // Update the state of the 'brand' entity to Modified for saving changes.
            _context.Entry(brand).State = EntityState.Modified;

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
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

        // POST: api/Brands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
             // Check if the 'Brands' entity set is null, and return a problem if it is.
          if (_context.Brands == null)
          {
              return Problem("Entity set 'ApplicationDBContext.Brands'  is null.");
          }
            // Add the 'brand' to the entity set and save changes to the database.
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            // Return a success response with the created brand and its ID.
            return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            // Check if the 'Brands' entity set is null, and return NotFound if it is.
            if (_context.Brands == null)
            {
                return NotFound();
            }
            // Find a brand by its ID.
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            // Remove the brand from the entity set and save changes to the database.
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrandExists(int id)
        {
            // Check if a brand with the given ID exists in the entity set.
            return (_context.Brands?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
