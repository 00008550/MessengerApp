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
        Task<string> CreateToken(AppUser user);
    }
}
