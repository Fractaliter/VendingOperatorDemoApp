using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace VendingOperator.Server.Models
{
    public class VendingMachineRepository : IVendingMachineRepository
    {
        private readonly AppDbContext _appDbContext;

        public VendingMachineRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<VendingMachine> AddVendingMachine(VendingMachine vendingMachine)
        {
            var result = await _appDbContext.VendingMachines.AddAsync(vendingMachine);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<VendingMachine?> DeleteVendingMachine(int vendingMachineId)
        {
            var result = await _appDbContext.VendingMachines.FirstOrDefaultAsync(p => p.VendingMachineId == vendingMachineId);
            if (result!=null)
            {
                _appDbContext.VendingMachines.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Vending Machine not found");
            }
            return result;
        }

        public async Task<VendingMachine?> GetVendingMachine(int vendingMachineId)
        {
            var result = await _appDbContext.VendingMachines
                .Include(vm => vm.User) // Eagerly load the related User entity
                .FirstOrDefaultAsync(p => p.VendingMachineId == vendingMachineId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Vending Machine not found");
            }
        }

        public PagedResult<VendingMachine> GetVendingMachines(string? vendingMachineName, int page)
        {
            int pageSize = 5;
            
            if (vendingMachineName != null)
            {
                return _appDbContext.VendingMachines
                    .Include(vm => vm.User) // Eagerly load the related User entity
                    .Where(p => p.VendingMachineName.Contains(vendingMachineName, StringComparison.CurrentCultureIgnoreCase))
                    .GetPaged(page, pageSize);
            }
            else
            {
                return _appDbContext.VendingMachines
                    .Include(vm => vm.User) // Eagerly load the related User entity
                    .GetPaged(page, pageSize);
            }
        }

        public async Task<VendingMachine?> UpdateVendingMachine(VendingMachine vendingMachine)
        {
            var result = await _appDbContext.VendingMachines.FirstOrDefaultAsync(p => p.VendingMachineId == vendingMachine.VendingMachineId);
            if (result!=null)
            {
                // Update existing VendingMachine
                _appDbContext.Entry(result).CurrentValues.SetValues(vendingMachine);
                

                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Vending Machine not found");
            }
            return result;
        }
    }
}