using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.Models.ModelViews
{
    public class AccountView
    {
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Email is Invalid!!")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public int Role { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public bool Status { get; set; }



        [Compare(nameof(Password), ErrorMessage = "Confirm Password is not match !!")]
        public string ConfirmPassword { get; set; }
    }
}
