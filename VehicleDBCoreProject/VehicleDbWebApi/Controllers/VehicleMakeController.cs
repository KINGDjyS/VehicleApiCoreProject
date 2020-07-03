using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {

        protected IVehicleMakeService Service { get; private set; }

        public VehicleMakeController(IVehicleMakeService service)
        {
            Service = service;
        }

        // GET: api/VehicleMake
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Service.GetVehicleMakersAsync());
        }

        // GET api/Vehicle/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var make = await Service.GetVehicleMakerAsync(id);

            if (make == null)
            {
                return NotFound();
            }
            return Ok(make);
        }

        // POST api/VehicleMake
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VehicleMake newMaker)
        {
            await Service.AddVehicleMakerAsync(newMaker);
            return CreatedAtAction(nameof(Get), new { id = newMaker.VehicleMakeId }, newMaker);
        }

        // PUT api/VehicleMake/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VehicleMake changeMaker)
        {
            if (id != changeMaker.VehicleMakeId)
            {
                return BadRequest();
            }

            if (await Service.MakerExists(id))
            {
                await Service.UpdateVehicleMakerAsync(changeMaker);
                return Ok();
            }

            return NoContent();
        }

        // DELETE api/VehicleMake/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await Service.MakerExists(id))
            {
                await Service.DeleteVehicleMakerAsync(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
