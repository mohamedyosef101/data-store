using System;
using System.Collections.Generic;

namespace data_store.Models;

public partial class Testimonial
{
    public int Id { get; set; }

    public string PersonName { get; set; } = null!;

    public string? JobTitle { get; set; }

    public string Quote { get; set; } = null!;

    public string? PersonImg { get; set; }
}
