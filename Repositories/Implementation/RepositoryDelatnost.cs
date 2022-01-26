using FPIS.Entities;
using FPIS.Entities._1_Identifikacija_novih_klijenata;
using FPIS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FPIS.Repositories.Implementation
{
    public class RepositoryDelatnost : IRepositoryDelatnost
    {
        private Context context;

        public RepositoryDelatnost(Context context)
        {
            this.context = context;
        }
        public async Task<List<Delatnost>> GetAllDelatnost()
        {
            return await context.Delatnost.ToListAsync();
        }
    }
}
