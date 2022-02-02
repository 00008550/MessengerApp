using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound(Guid id)
        {
            var thing = _context.Users.Find(id);
            if (thing == null) return NotFound();
            return Ok(thing); 
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError(Guid id)
        {
            var thing = _context.Users.Find(id);

            var thingToReturn = thing.ToString();
            return thingToReturn;
        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This is not good request");
        }
        

    }
}
