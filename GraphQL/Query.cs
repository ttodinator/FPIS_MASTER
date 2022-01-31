using FPIS.Entities;
using FPIS.Entities._1_Identifikacija_novih_klijenata;
using FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace FPIS.GraphQL
{
    public class Query
    {
        [HotChocolate.AspNetCore.Authorization.Authorize]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<Delatnost> GetDelatnost1([Service] Context context)
        {
            return context.Delatnost.ToList();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<Delatnost> GetDelatnost([Service] Context context, [GraphQLName("sifraDel")] int sifraDel)
        {
            return context.Delatnost.Where(x => x.SifraDel == sifraDel).ToList();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Valuta>> GetValuta([Service] Context context)
        {
            return await context.Valuta.ToListAsync();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<Delatnost> GetDelatnost15656([Service] Context context, [GraphQLName("sifraDel")] int sifraDel)
        {
            return context.Delatnost.Where(x => x.SifraDel != sifraDel).ToList();
        }
    }
}
