using CSharpBackend.DTOs;
using CSharpBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharpBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _titleService;

        public PostController(IPostService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get()
        {
            return await _titleService.Get();
        }
    }
}
