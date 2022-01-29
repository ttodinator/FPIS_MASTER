using FPIS.Entities;

namespace FPIS.JWT
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
