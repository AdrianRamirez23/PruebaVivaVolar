using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Middleware
{
    public interface IJWTAuthenticationManager
    {
       string Autheticate(string UserName);
    }
}
