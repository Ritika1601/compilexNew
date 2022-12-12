using System;
using System.Collections.Generic;

namespace compilex.Models
{
    public partial class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = null!;
        public int Price { get; set; }
        public string Details { get; set; } = null!;
    }
}
