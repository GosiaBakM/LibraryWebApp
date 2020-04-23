﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class Author
    {
      
        public int AutorId { get; private set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string AuthorFullName { get; set; }

        public override string ToString()
        {
            return $"{AuthorFullName}";
        }

    }
}
