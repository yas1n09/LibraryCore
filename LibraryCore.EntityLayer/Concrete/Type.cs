﻿using LibraryCore.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.EntityLayer.Concrete
{
    public class Type : IEntity     //Kitap türü için sınıf 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<Book> ?Books { get; set; }
    }
}
