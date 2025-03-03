using Academy_2025.Data;
using Academy_2025.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseRepository _courseRepository;

        public CourseController()
        {
            _courseRepository = new CourseRepository();
        }

        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _courseRepository.GetAll();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            var course = _courseRepository.GetById(id);
            return course == null ? NotFound() : course;
        }

        // POST api/<CourseController>
        [HttpPost]
        public ActionResult Post([FromBody] Course data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _courseRepository.Create(data);

            return NoContent();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult<Course> Put(int id, [FromBody] Course data)
        {
            var course = _courseRepository.Update(id, data);
            return course == null ? NotFound() : course;
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _courseRepository.Delete(id);
            return result ? NoContent() : NotFound();
        }
    }
}
