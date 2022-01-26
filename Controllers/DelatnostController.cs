using FPIS.Entities._1_Identifikacija_novih_klijenata;
using FPIS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FPIS.Controllers
{
    public class DelatnostController: BaseApiController
    {
        IUnitOfWork unitOfWork;
        public DelatnostController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<List<Delatnost>> Vrati()
        {
            return await unitOfWork.RepositoryDelatnost.GetAllDelatnost();
        }
    }
}
