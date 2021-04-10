using HouseRentingSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseRentingSystem.Repository
{
    public interface IContractRepository
    {
        Task<int> AddContract(int adid, int cid, int tenantId);
        Task<List<ContractsModel>> GetContractsByUserId(int userId);
    }
}