using System;
using System.Collections.Generic;

namespace compilex.Models
{
    public partial class CreateUser
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string CurrentComapany { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string Industry { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Resume { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string CollegeName { get; set; } = null!;
        public string YearOfPassing { get; set; } = null!;
    }
}
