using HouseRentingSystem.Data;
using HouseRentingSystem.Models;
using HouseRentingSystem.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentingSystem.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly HouseRentingSystemDBContext _context = null;
        private readonly IUserService _userService = null;

        public ContractRepository(HouseRentingSystemDBContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<List<ContractsModel>> GetContractsByUserId(int userId)
        {
            List<ContractsModel> contractsModels = new List<ContractsModel>();
            var contracts = await _context.Contracts.Where(x => x.Tenantid == userId).ToListAsync();
            if (contracts != null && contracts.Count > 0)
            {
                foreach (var contract in contracts)
                {
                    contractsModels.Add(new ContractsModel()
                    {
                        Contractid=contract.Contractid,
                        TenantName= _userService.GetUserName(),
                        Startdate=contract.Startdate,
                        Monthlyrent=contract.Monthlyrent,
                        Adid=contract.Adid,
                        HouseownerName=contract.HouseownerName

                    });
                }

            }
            return contractsModels;
        }

        public async Task<int> AddContract(int adid, int cid, int tenantId)
        {
            var query = from c in _context.Advertisements
                        where c.Adid == adid
                        select c;
            var ad = query.FirstOrDefault<Advertisements>();
            var newContract = new Contracts
            {
                Adid = adid,
                CreditCardId = cid,
                HouseownerName = ad.ContactPerson,
                Tenantid = tenantId,
                Startdate = DateTime.UtcNow,
                Monthlyrent = ad.Rental
            };
            await _context.Contracts.AddAsync(newContract);
            await _context.SaveChangesAsync();

            return newContract.Adid;
        }
    }
}
