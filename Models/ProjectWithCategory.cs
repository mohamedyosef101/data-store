using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace data_store.Models
{
    public class ProjectWithCategory
    {
        public required Project Project { get; set; }
        public string? CategoryName { get; set; }
    }
}