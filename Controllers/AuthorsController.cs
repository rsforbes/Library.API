using AutoMapper;
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

            var authors = Mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);
            
            return new JsonResult(authors);
        }
    }
}