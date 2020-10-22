using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mycars.Helpers
{
    public class AuthOptions
    {
        public const string KEY = "duhashdiSIDWINKSHAJHSDJKHAJKHjahd";
        public  static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
