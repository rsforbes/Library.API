using System;
using System.Collections.Generic;

namespace Library.API.Models
{
    public class AuthorForCreationDto
    {
        public string FirstName;
        public string LastName;
        public DateTimeOffset DateOfBirth;
        public string Genre;
        public ICollection<BookForCreationDto> Books = new List<BookForCreationDto>();

    }
}