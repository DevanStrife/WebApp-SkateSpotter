using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkateSpotter_MVC.Data;
using SkateSpotter_MVC.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkateSpotter_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StoreController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/<ShopController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetAll()
        {
            return await _context.Stores
                .ToListAsync();
        }
        // GET api/<ShopController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        // POST api/<ShopController>
        [HttpPost]
        public async Task<ActionResult<Store>> PostStore(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetStore),
                new { id = store.Id },
                store);
        }

        // PUT api/<ShopController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore(int id, Store store)
        {
            if (id != store.Id)
            {
                return BadRequest();
            }

            var storeToUpdate = await _context.Stores.FindAsync(id);

            if (storeToUpdate == null)
            {
                return NotFound();
            }

            storeToUpdate.Name = store.Name;
            storeToUpdate.Description = store.Description;
            storeToUpdate.Country = store.Country;
            storeToUpdate.State = store.State;
            storeToUpdate.City = store.City;
            storeToUpdate.Adress = store.Adress;
            storeToUpdate.ZipCode = store.ZipCode;
            storeToUpdate.PhoneNumber = store.PhoneNumber;
            storeToUpdate.Email = store.Email;
            storeToUpdate.Website = store.Website;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!StoreExists(id))
            {
                return NotFound();
            }
            
            return NoContent();
        }


        // DELETE api/<ShopController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreExists(int id)
        {
            return _context.Stores.Any(e => e.Id == id);
        }

    }
}
