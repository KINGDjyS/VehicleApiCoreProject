﻿using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Service.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vehicle.VehicleDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        protected IVehicleModelService Service { get; private set; }

        protected IMapper Mapper;

        public VehicleModelController(IVehicleModelService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        // GET: api/VehicleModel
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Filtering filtering, [FromQuery] Sorting sorting, [FromQuery] Paging paging)
        {
            paging.PageSize = 5;

            var models = await Service.GetVehicleModelsAsync(filtering, sorting, paging);
            return Ok(models);
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
        public async Task<IActionResult> Post([FromBody] VehicleModelRest newModel)
        {
            await Service.AddVehicleModelAsync(Mapper.Map<Vehicle.Model.VehicleModel>(newModel));
            return CreatedAtAction(nameof(Get), new { id = newModel.VehicleModelId }, newModel);
        }

        // PUT api/VehicleModel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VehicleModelRest changeModel)
        {
            if (id != changeModel.VehicleModelId)
            {
                return BadRequest();
            }

            if (await Service.ModelExists(id))
            {
                await Service.UpdateVehicleModelAsync(id, Mapper.Map<Vehicle.Model.VehicleModel>(changeModel));
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
