using VendingOperator.Server.Authorization;
using VendingOperator.Server.Models;
using VendingOperator.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace VendingOperator.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VendingMachineController : ControllerBase
    {

        private readonly IVendingMachineRepository _vendingMachineRepository;

        public VendingMachineController(IVendingMachineRepository vendingMachineRepository)
        {
            _vendingMachineRepository = vendingMachineRepository;
        }
        /// <summary>
        /// Returns a list of paginated people with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetVendingMachines([FromQuery] string? vendingMachineName, int page)
        {
            return Ok(_vendingMachineRepository.GetVendingMachines(vendingMachineName, page));
        }

        /// <summary>
        /// Gets a specific person by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetVendingMachine(int id)
        {
            return Ok(await _vendingMachineRepository.GetVendingMachine(id));
        }

        /// <summary>
        /// Creates a person with child addresses.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddVendingMachine(VendingMachine person)
        {
            return Ok(await _vendingMachineRepository.AddVendingMachine(person));
        }

        /// <summary>
        /// Updates a person with a specific Id.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateVendingMachine(VendingMachine person)
        {
            return Ok(await _vendingMachineRepository.UpdateVendingMachine(person));
        }

        /// <summary>
        /// Deletes a person with a specific Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVendingMachine(int id)
        {
            return Ok(await _vendingMachineRepository.DeleteVendingMachine(id));
        }
    }
}
