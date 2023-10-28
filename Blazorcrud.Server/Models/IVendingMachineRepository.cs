using Blazorcrud.Shared.Data;
using Blazorcrud.Shared.Models;
using System.Reflection.PortableExecutable;

namespace Blazorcrud.Server.Models
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