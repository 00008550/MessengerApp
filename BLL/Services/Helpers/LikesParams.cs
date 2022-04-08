using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.Helpers
{
    public class LikesParams : PaginationParams
    {
        public Guid UserId { get; set; }
        public string Predicate { get; set; }
        
    }
}