﻿using System;
using System.Collections.Generic;

namespace Q2_SP25_ThuVienBook.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
