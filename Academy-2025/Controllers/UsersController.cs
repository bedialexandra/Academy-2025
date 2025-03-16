using Academy_2025.Data;
using Academy_2025.DTOs;
using Academy_2025.Repositories;
using Academy_2025.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        /*public UsersController()
        {
            Users = new List<User>
            { 
                new User { Id=1, FirstName="Anna", LastName="Teszt"},
                new User { Id = 2, FirstName = "Péter", LastName = "Teszt" }
            };
        }*/
        // GET: api/<UsersController>
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAsync()
        {
            return await _userService.GetAllAsync();
        }

        [Authorize]
        [HttpGet("/age")]
        public async Task<IEnumerable<User>> GetAgeAsync()
        {
            
            return await _userService.GetOlderEightteenAsync();
           
        }


        // GET api/<UsersController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetAsync(int id)
        {
            var user=await _userService.GetByIdAsync(id);
            return user==null?NotFound():user;
        }

        // POST api/<UsersController>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] UserDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.CreateAsync(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutAsync(int id, [FromBody] UserDto data)
        {
            var user = await _userService.UpdateAsync(id,data);
            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }

    }
}
