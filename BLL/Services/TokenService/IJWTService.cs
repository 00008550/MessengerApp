using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.TokenService
{
    public interface IJWTService
    {
        string CreateToken(AppUser user);
    }
}
