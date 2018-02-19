using System;

namespace Library.API.Models
{
    public class AuthorForCreationDto
    {
        public string FirstName;
        public string LastName;
        public DateTimeOffset DateOfBirth;
        public string Genre;
    }
}