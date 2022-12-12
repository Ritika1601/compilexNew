using System;
using System.Collections.Generic;

namespace compilex.Models
{
    public partial class AddJob
    {
        public string JobTitle { get; set; } = null!;
        public string WorkPlaceType { get; set; } = null!;
        public string JobLocation { get; set; } = null!;
        public string Company { get; set; } = null!;
        public string JobType { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UserName { get; set; } = null!;

        public virtual CreateUser UserNameNavigation { get; set; } = null!;
    }
}
