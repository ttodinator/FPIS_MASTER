using FPIS.Entities;
using FPIS.Entities._1_Identifikacija_novih_klijenata;
using HotChocolate;

namespace FPIS.GraphQL
{
    public class Query
    {
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
        public List<Delatnost> GetDelatnost15656([Service] Context context, [GraphQLName("sifraDel")] int sifraDel)
        {
            return context.Delatnost.Where(x => x.SifraDel != sifraDel).ToList();
        }
    }
}
