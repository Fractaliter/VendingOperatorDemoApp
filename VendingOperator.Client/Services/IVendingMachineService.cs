using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;

namespace VendingOperator.Client.Services
{
    public interface IVendingMachineService
    {
        Task<PagedResult<VendingMachine>> GetVendingMachines(string? vendingMachineName, string page);
        Task<VendingMachine> GetVendingMachine(int id);

        Task DeleteVendingMachine(int id);

        Task AddVendingMachine(VendingMachine vendingMachine);

        Task UpdateVendingMachine(VendingMachine vendingMachine);
    }
}