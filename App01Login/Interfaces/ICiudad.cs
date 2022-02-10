using App01Login.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01Login.Interfaces
{
    internal interface ICiudad
    {
        Task<List<Ciudad>> GetAuthCiudadesAsync(string token);
    }
}
