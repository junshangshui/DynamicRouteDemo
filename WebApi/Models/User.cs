using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class User
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }
    }
}
