using System;
using System.Collections.Generic;

namespace WebApplicationTrupi.Models;

public partial class Bookstable
{
    public int Bookid { get; set; }

    public string Bookname { get; set; } = null!;

    public string Bookauthor { get; set; } = null!;

    public decimal Bookprice { get; set; }
}
