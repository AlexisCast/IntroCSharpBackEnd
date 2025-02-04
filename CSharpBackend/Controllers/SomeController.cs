using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharpBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Thread.Sleep(2500);
            Console.WriteLine("Conection to a DB finished...");

            Thread.Sleep(2500);
            Console.WriteLine("Email sent finished...");

            Console.WriteLine("Everything has finished...");

            stopwatch.Stop();

            return Ok(stopwatch.Elapsed);
        }
    }
}
