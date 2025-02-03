using CSharpBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharpBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController([FromKeyedServices("people2Service")] IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public List<People> GetPeople()
        {
            return Repository.People;
        }

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id)
        {
            var people = Repository.People.FirstOrDefault(p => p.Id == id);

            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search)
        {
            return Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();
        }

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }

            Repository.People.Add(people);
            return NoContent();
        }
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People { Id = 1, Name = "John", BirthDate = new DateTime(1990, 1, 11), Age = 30 },
            new People { Id = 2, Name = "Jane", BirthDate = new DateTime(1991, 2, 12), Age = 29 },
            new People { Id = 3, Name = "Jack", BirthDate = new DateTime(1992, 3, 13), Age = 28 },
            new People { Id = 4, Name = "Jill", BirthDate = new DateTime(1993, 4, 14), Age = 27 },
            new People { Id = 5, Name = "Joe", BirthDate = new DateTime(1994, 5, 15), Age = 26 },
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
    }
}
