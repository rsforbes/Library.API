using Microsoft.AspNetCore.Mvc;
using Library.API.Services;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private ILibraryRepository _libraryRespository;
        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _libraryRespository = libraryRepository;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _libraryRespository.GetAuthors();
            return new JsonResult(authorsFromRepo);
        }
    }
}