﻿using System;
using System.Collections.Generic;

namespace Q2_SP25_ThuVienBook.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public int? BirthYear { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
