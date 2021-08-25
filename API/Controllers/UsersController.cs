﻿using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
             return await _context.Users.ToListAsync();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(Guid Id)
        {
            return await _context.Users.FindAsync(Id);

        }
    }
}
