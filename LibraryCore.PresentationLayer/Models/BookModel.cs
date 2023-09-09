﻿using LibraryCore.EntityLayer.Concrete;

namespace LibraryCore.PresentationLayer.Models
{
    public class BookModel
    {
        public List<Book> Books { get; set; }
        public Book Book { get; set; }
        public ImageBook ImageBook { get; set; }
        public List<AuthorWithFullName> Authors { get; set; }
        public List<EntityLayer.Concrete.Type> Types { get; set; }
    }
}