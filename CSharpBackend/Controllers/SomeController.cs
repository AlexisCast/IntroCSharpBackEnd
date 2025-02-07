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

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(2500);
                Console.WriteLine("Conection to a DB finished...");
                return 8;
            });

            task1.Start();

            Console.WriteLine("Do other thing...");

            var result1 = await task1;

            Console.WriteLine("Everything has finished...");

            return Ok(result1);
        }
    }
}
