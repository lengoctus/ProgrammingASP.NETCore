using System;
using System.Collections.Generic;

namespace MyLib.Models.Entities
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public int Role { get; set; }
        public string FullName { get; set; }
        public bool? Active { get; set; }
        public bool? Status { get; set; }
    }
}
