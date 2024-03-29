﻿using FPIS.Entities;
using FPIS.JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPIS.Controllers
{
    public class AccountController : BaseApiController
    {
        UserManager<AppUser> userManager;
        SignInManager<AppUser> signInManager;
        private ITokenService tokenService;
        // private IMapper mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.tokenService = tokenService;
            //this.mapper = mapper;
        }

        

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            if (user == null) return Unauthorized("Invalid username");

            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized();


            List<int> likes = new List<int>();

            return new UserDto
            {
                Username = user.UserName,
                Token = await tokenService.CreateToken(user),

            };
        }


        private async Task<bool> UserExists(string username)
        {
            return await userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }


    }
}
