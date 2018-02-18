using System;

namespace Library.API.Models
{
    public class BookDto
    {
        public Guid Id;
        public string Title;
        public string Description;
        public Guid AuthorId;
    }
}