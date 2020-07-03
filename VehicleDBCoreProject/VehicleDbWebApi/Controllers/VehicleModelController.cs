﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        protected IVehicleModelService Service { get; private set; }

        public VehicleModelController(IVehicleModelService service)
        {
            Service = service;
        }

        // GET: api/VehicleModel
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Service.GetVehicleModelsAsync());
        }

        // GET api/VehicleModel/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await Service.GetVehicleModelAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        // POST api/VehicleModel
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VehicleModel newModel)
        {
            await Service.AddVehicleModelAsync(newModel);
            return CreatedAtAction(nameof(Get), new { id = newModel.VehicleModelId }, newModel);
        }

        // PUT api/VehicleModel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VehicleModel changeModel)
        {
            if (id != changeModel.VehicleModelId)
            {
                return BadRequest();
            }

            if (await Service.ModelExists(id))
            {
                await Service.UpdateVehicleModelAsync(changeModel);
                return Ok();
            }

            return NoContent();
        }

        // DELETE api/VehicleModel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await Service.ModelExists(id))
            {
                await Service.DeleteVehicleModelAsync(id);
                return Ok();
            }
            return NotFound();
        }
    }
}