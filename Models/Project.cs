using System;
using System.Collections.Generic;

namespace data_store.Models;

public partial class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Info { get; set; }

    public byte[]? Img { get; set; }

    public int CategoryId { get; set; }

    public string? ImgUrl { get; set; }

    public virtual Category Category { get; set; } = null!;
}
