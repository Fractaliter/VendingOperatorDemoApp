using Blazorcrud.Client.Shared;
using Blazorcrud.Shared.Data;
using Blazorcrud.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Blazorcrud.Client.Services
{
    public class VendingMachineService : IVendingMachineService
    {
        private IHttpService _httpService;

        public VendingMachineService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<PagedResult<VendingMachine>> GetVendingMachines(string? name, string page)
        {
            return await _httpService.Get<PagedResult<VendingMachine>>("api/vendingMachine" + "?page=" + page + "&name=" + name);
        }

        public async Task<VendingMachine> GetVendingMachine(int id)
        {
            return await _httpService.Get<VendingMachine>($"api/vendingMachine/{id}");
        }

        public async Task DeleteVendingMachine(int id)
        {
            await _httpService.Delete($"api/vendingMachine/{id}");
        }

        public async Task AddVendingMachine(VendingMachine person)
        {
            await _httpService.Post($"api/vendingMachine", person);
        }

        public async Task UpdateVendingMachine(VendingMachine vendingMachine)
        {
            await _httpService.Put($"api/vendingMachine", vendingMachine);
        }
    }
}