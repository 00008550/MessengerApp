using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Helpers;

namespace BLL.Repository
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(Guid id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<PagedList<MemberDTO>> GetMembersAsync(UserParams userParams);
        Task<MemberDTO> GetMemberAsync(string username);
    }
}
