using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Domain.Models
{
    public class ApplicationUserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }
    }
}
