using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Domain.Models
{
    public class ApplicationUser
    {
        public string UserName { get; set; }
        public int CreateByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public object Id { get; set; }
    }
}
