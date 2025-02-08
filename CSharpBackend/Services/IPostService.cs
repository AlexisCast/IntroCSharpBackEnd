using CSharpBackend.DTOs;

namespace CSharpBackend.Services
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDto>> Get();
    }
}
