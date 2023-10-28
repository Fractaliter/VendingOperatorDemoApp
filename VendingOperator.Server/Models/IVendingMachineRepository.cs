using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;
using System.Reflection.PortableExecutable;

namespace VendingOperator.Server.Models
{
    public interface IVendingMachineRepository
    {
        PagedResult<VendingMachine> GetVendingMachines(string? vendingMachineName, int page);
        Task<VendingMachine?> GetVendingMachine(int vendingMachineId);
        Task<VendingMachine> AddVendingMachine(VendingMachine vndingMachine);
        Task<VendingMachine?> UpdateVendingMachine(VendingMachine vendingMachine);
        Task<VendingMachine?> DeleteVendingMachine(int vendingMachineId);
    }
}