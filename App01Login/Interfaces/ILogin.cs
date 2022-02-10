﻿using App01Login.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01Login.Interfaces
{
    interface ILogin
    {
        Task<Login> Authenticate(UserMin user);
    }
}
