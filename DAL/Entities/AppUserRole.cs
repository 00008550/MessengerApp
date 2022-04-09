using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class AppUserRole: IdentityUserRole<Guid>
    {
        public AppUser User { get; set; }
        public AppRole Role {get;set;}
    }
}