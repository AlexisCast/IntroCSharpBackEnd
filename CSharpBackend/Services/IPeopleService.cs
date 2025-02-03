using CSharpBackend.Controllers;

namespace CSharpBackend.Services
{
    public interface IPeopleService
    {
        bool Validate(People people);
    }
}
