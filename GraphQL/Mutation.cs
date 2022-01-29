using FPIS.Controllers;
using FPIS.Entities;
using FPIS.Entities._1_Identifikacija_novih_klijenata;
using FPIS.JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FPIS.GraphQL
{
    public class Mutation
    {
        //UserManager<AppUser> userManager;
        //SignInManager<AppUser> signInManager;
        private ITokenService tokenService;

        public Mutation(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }
        public async Task<Delatnost> AddDelatnost([Service] Context context, Delatnost delatnost)
        {
            return delatnost;
        }

        public async Task<UserDto> Login([Service] Context context,
            [Service]  UserManager<AppUser> userManager,
            [Service]  SignInManager<AppUser> signInManager,
            LoginDto loginDto)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return null;
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = await tokenService.CreateToken(user),

            };
        }
    }
}
