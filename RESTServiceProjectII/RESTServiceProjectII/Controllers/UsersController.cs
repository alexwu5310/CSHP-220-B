using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTServiceProjectII.Models;

namespace RESTServiceProjectII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> users = new List<User>();
        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var user = users.FirstOrDefault(t => t.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return new OkObjectResult(user);
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            if (value == null || value.Email == null || value.Password == null)
            {
                return new BadRequestResult();
            }

            value.Id = Guid.NewGuid();
            value.CreatedDate = DateTime.Now;

            users.Add(value);

            return CreatedAtAction(nameof(Get),
                new { id = value.Id },
                value);

        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] User value)
        {
            var user = users.FirstOrDefault(t => t.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.Id = id;
            user.Email = value.Email;
            user.Password = value.Password;

            return Ok(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var usersRemoved = users.RemoveAll(t => t.Id == id);

            if (usersRemoved == 0)
            {
                return NotFound();
            }

            return Ok(); 
        }
    }
}
