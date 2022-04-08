using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserLike
    {
        public AppUser SourceUser { get; set; }
        public Guid SourceUserId { get; set; }

        public AppUser LikedUser {get;set;}
        public Guid LikedUserId {get;set;}
    }
}