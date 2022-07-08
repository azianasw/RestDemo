using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RestDemo.Models
{
    public partial class Employee
    {
        public long Id { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
