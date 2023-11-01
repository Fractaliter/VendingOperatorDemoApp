using VendingOperator.Client.Shared;
using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;
using System.Web.Http;

namespace VendingOperator.Client.Services
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
            return await _httpService.Get<PagedResult<VendingMachine>>("api/vendingmachine" + "?page=" + page + "&name=" + name);
        }

        public async Task<VendingMachine> GetVendingMachine(int id)
        {
            return await _httpService.Get<VendingMachine>($"api/vendingmachine/{id}");
        }

        public async Task DeleteVendingMachine(int id)
        {
            await _httpService.Delete($"api/vendingmachine/{id}");
        }

        public async Task AddVendingMachine([FromBody]VendingMachine person)
        {
            await _httpService.Post($"api/vendingmachine", person);
        }

        public async Task UpdateVendingMachine(VendingMachine vendingMachine)
        {
            await _httpService.Put($"api/vendingmachine", vendingMachine);
        }
    }
}