using Microsoft.AspNetCore.Mvc;
using Library.API.Services;

namespace Library.API.Controllers
{
    public class AuthorsController : Controller
    {
        private ILibraryRepository _libraryRespository;
        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _libraryRespository = libraryRepository;
        }
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _libraryRespository.GetAuthors();
            return new JsonResult(authorsFromRepo);
        }
    }
}