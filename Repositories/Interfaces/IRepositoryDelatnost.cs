using FPIS.Entities._1_Identifikacija_novih_klijenata;

namespace FPIS.Repositories.Interfaces
{
    public interface IRepositoryDelatnost
    {
        Task<List<Delatnost>> GetAllDelatnost();
    }
}
