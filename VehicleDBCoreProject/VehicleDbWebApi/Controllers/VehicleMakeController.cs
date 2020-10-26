using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Common;
using Vehicle.Service.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vehicle.VehicleDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {

        protected IVehicleMakeService Service { get; private set; }

        protected IMapper Mapper;

        public VehicleMakeController(IVehicleMakeService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        // GET: api/VehicleMake
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Filtering filtering, [FromQuery]Sorting sorting, [FromQuery] Paging paging)
        {
            paging.PageSize = 3;
            
            var makers = await Service.GetVehicleMakersAsync(filtering, sorting, paging);
            return Ok(makers);
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
        public async Task<IActionResult> Post([FromBody] VehicleMakeRest newMaker)
        {
            await Service.AddVehicleMakerAsync(Mapper.Map<Vehicle.Model.VehicleMake>(newMaker));
            //return CreatedAtAction(nameof(Get), new { id = newMaker.VehicleMakeId }, newMaker);
            return Ok();
        }

        // PUT api/VehicleMake/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VehicleMakeRest changeMaker)
        {
            if (id != changeMaker.VehicleMakeId)
            {
                return BadRequest();
            }

            if (await Service.MakerExists(id))
            {
                await Service.UpdateVehicleMakerAsync(id, Mapper.Map<Vehicle.Model.VehicleMake>(changeMaker));
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
