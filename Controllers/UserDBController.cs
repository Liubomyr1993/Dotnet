
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dotnet.Data;
using Dotnet.models;


namespace Dotnet.Controllers
{
    
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class UserDBController : ControllerBase
    {
        private readonly DataContext _context;

        public UserDBController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.newusers.Where(c => c.IsDeleted == false).ToListAsync();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var contact = await _context.newusers.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Users contact)
        {
            var dbContact = await _context.newusers.FindAsync(id);
            if (dbContact == null)
            {
                return NotFound();
            }

            dbContact.FirstName = contact.FirstName;
            dbContact.LastName = contact.LastName;
            dbContact.BirthDay = contact.BirthDay;
            

            await _context.SaveChangesAsync();

            return Ok(dbContact);
        }

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostContact(Users contact)
        {
            _context.newusers.Add(contact);
            await _context.SaveChangesAsync();

            return Ok(_context.newusers);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.newusers.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            contact.IsDeleted = true;

            await _context.SaveChangesAsync();

            return Ok(_context.newusers);
        }

        private bool ContactExists(int id)
        {
            return _context.newusers.Any(e => e.Id == id);
        }
    }
}