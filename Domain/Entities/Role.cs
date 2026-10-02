using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    internal class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
