using System;
using System.Collections.Generic;

namespace data_store.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public byte[]? Img { get; set; }

    public string? ImgUrl { get; set; }
}
