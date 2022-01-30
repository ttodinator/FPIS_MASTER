using FPIS.Controllers;
using FPIS.Entities;
using FPIS.Entities._1_Identifikacija_novih_klijenata;
using FPIS.JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FPIS.GraphQL
{
    public class Mutation
    {
        private ITokenService tokenService;
        IConfiguration config;
        //private Context context;

        public Mutation(Context context, IConfiguration config)
        {
            this.config = config;
        }
        public async Task<Delatnost> AddDelatnost([Service] Context context, Delatnost delatnost)
        {
            context.Add(delatnost);
            return delatnost;
        }

        public async Task<UserDto> Login([Service] Context context,
            [Service] SignInManager<AppUser> signInManager,
            [Service] UserManager<AppUser> userManager,
            [Service] ITokenService tokenService,
            LoginDto loginDto)
        {
            //var user = await userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            var user = await context.AppUser.SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return null;
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = await tokenService.CreateToken(user)

            };
        }


        private async Task<string> createTokenAsync(UserManager<AppUser> userManager, AppUser user )
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName)
            };

            var roles = await userManager.GetRolesAsync(user);


            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
