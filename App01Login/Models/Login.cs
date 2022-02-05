using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01Login.Models
{
    public class Login : User
    {
        public string Token { get; set; }
    }
}
