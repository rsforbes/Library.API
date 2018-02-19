using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Library.API.Services;
using System.Collections.Generic;
using System.Linq;
using Library.API.Models;
using Library.API.Entities;
using Library.API.Helpers;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Library.API.Controllers
{
    [Route("api/authorcollections")]
    public class AuthorCollectionsController : Controller
    {
        private ILibraryRepository _libraryRespository;
        public AuthorCollectionsController(ILibraryRepository libraryRepository)
        {
            _libraryRespository = libraryRepository;
        }

        [HttpPost]
        public IActionResult CreateAuthorCollection([FromBody] IEnumerable<AuthorForCreationDto> authorCollection)
        {
            if (authorCollection == null)
            {
                return BadRequest();
            }

            var authorEntitiies = Mapper.Map<IEnumerable<Author>>(authorCollection);

            foreach (var author in authorEntitiies)
            {
                 _libraryRespository.AddAuthor(author);

            }

            if (!_libraryRespository.Save())
            {
                throw new Exception("Createing an author collection failed on save.");
            }

            var authorCollectionToReturn = Mapper.Map<IEnumerable<AuthorDto>>(authorEntitiies);
            var idsAsString = string.Join(",", authorCollectionToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetAuthorCollection", new { ids = idsAsString}, authorCollectionToReturn);
        }

        //(key1,key2, ...)
        [HttpGet("({ids})", Name="GetAuthorCollection")]
        public IActionResult GetAuthorCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var authorEntitiies = _libraryRespository.GetAuthors(ids);

            if (ids.Count() != authorEntitiies.Count())
            {
                return NotFound();
            }

            var authorsToReturn = Mapper.Map<IEnumerable<AuthorDto>>(authorEntitiies);
            return Ok(authorsToReturn);
        }
    }
}