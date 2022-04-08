using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Services.Helpers;
using DAL.Entities;

namespace BLL.Repository
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(Guid sourceUserId, Guid likedUserId);

        Task<AppUser> GetUserWithLikes(Guid userId);
        Task<PagedList<LikeDTO>> GetUserLikes(LikesParams likesParams);
    }
}