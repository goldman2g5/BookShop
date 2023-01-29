using System;
using System.Collections.Generic;

namespace KebabPiercingApi.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Author { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string YearPosted { get; set; } = null!;
}
