using Academy_2025.Data;
using Academy_2025.Repositories;
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
        private readonly UserRepository _repository;

        public UsersController()
        {
            _repository = new UserRepository();
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
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repository.GetAll();
        }

        

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user=_repository.GetById(id);
            return user==null?NotFound():user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Create(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User data)
        {
            var user = _repository.Update(id,data);
            return user == null ? NotFound() : user;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var result = _repository.Delete(id);
            return result ? NoContent() : NotFound();
        }

    }
}
