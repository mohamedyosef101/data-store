using System;
using System.Collections.Generic;

namespace data_store.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Details { get; set; }

    public string? Icon { get; set; }
}
