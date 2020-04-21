using System;
using System.Collections.Generic;
using celo_user_api.Models;
using celo_user_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace celo_user_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _dataRepository;
        public UserController(IUserRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = _dataRepository.GetAll();
            return Ok(users);
        }

        // GET: api/User/5

        [HttpGet("{id}", Name = "GerUser")]
        public IActionResult Get(int id)
        {
            IEnumerable<User> users = _dataRepository.GetAll();
            return Ok(users);
        }


        // GET: api/user/limit/1
        [HttpGet("limit/{limit}", Name = "GetUsersByLimit")]
        public IActionResult GetUsersByLimit(int limit)
        {
            IEnumerable<User> users = _dataRepository.GetUsersByLimit(limit);
            return Ok(users);
        }


        // GET: api/user/lastname/Bailey
        [HttpGet("lastname/{lastname}", Name = "GetUserByLastName")]
        public IActionResult GetUserByLastName(string lastName)
        {
            IEnumerable<User> users = _dataRepository.GetUsersByLastName(lastName);
            return Ok(users);
        }

        // GET: api/user/firstname/Norbert
        [HttpGet("firstname/{firstname}", Name = "GetUserByFirstName")]
        public IActionResult GetUserByFirstName(string firstName)
        {
            IEnumerable<User> users = _dataRepository.GetUsersByFirstName(firstName);
            return Ok(users);
        }


        // POST: api/User
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dataRepository.Add(user);
            return CreatedAtRoute(
                  "GetUser",
                  new { id = user.Id },
                  user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            User userToUpdate = _dataRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Update(user);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = _dataRepository.Get(id);
            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Delete(user);
            return NoContent();
        }
    }
}
