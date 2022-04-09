using AutoMapper;
using BLL.Models;
using BLL.Services.TokenService;
using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountController: BaseApiController
    {
        private readonly IJWTService _jwtService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;
        
        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, IJWTService jwtService, IMapper mapper)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _mapper = mapper;
            _signInManager = signInManager;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (await UserExists(registerDTO.Username)) return BadRequest("User name is taken");

            var user = _mapper.Map<AppUser>(registerDTO);

            user.UserName = registerDTO.Username.ToLower();


            var result = await _userManager.CreateAsync(user,registerDTO.Password);

            if(!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user , "Member");

            if(!roleResult.Succeeded) return BadRequest(result.Errors);

            return new UserDTO
            {
                Username = user.UserName,
                Token = await _jwtService.CreateToken(user),
                KnownAs = user.KnownAs,
                Gender = user.Gender
            };
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.Users
            .Include(p=>p.Photos)
            .SingleOrDefaultAsync(x => x.UserName.ToLower() == loginDTO.Username.ToLower());
            if (user == null) return Unauthorized("Invalid Username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password,false);

            if(!result.Succeeded) return Unauthorized();

            return new UserDTO
            {
                Username = user.UserName,
                Token = await _jwtService.CreateToken(user),
                PhotoUrl = user.Photos.FirstOrDefault(x=>x.IsMain)?.Url,
                KnownAs = user.KnownAs,
                Gender = user.Gender
            };
        }
        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
