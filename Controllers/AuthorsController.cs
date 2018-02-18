using Microsoft.AspNetCore.Mvc;
using Library.API.Services;
using System.Collections.Generic;
using Library.API.Models;
using Library.API.Helpers;

namespace Library.API.Controllers
{
    [Route("api/authors")]
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

            var authors = new List<AuthorDto>();

            foreach (var author in authorsFromRepo)
            {
                authors.Add(new AuthorDto()
                {
                    Id = author.Id,
                    Name = $"{author.FirstName} {author.LastName}",
                    Genre = author.Genre,
                    Age = author.DateOfBirth.GetCurrentAge(),
                });
            }

            return new JsonResult(authors);
        }
    }
}