using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Domain.Models
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; }
        public string Client_Url { get; set; }
    }
}
