using App01Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01Login.Interfaces
{
    internal interface ILogin
    {
     Task<Login> Authenticate(UserMin userMin);
    }
}
