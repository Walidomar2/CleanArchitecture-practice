using CleanArchitecute.Core.Entities;
using CleanArchitecute.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarServices _carServices;
        

        public CarController(ICarServices carServices)
        {
            _carServices = carServices;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carList = await _carServices.GetAllAsync();
            return Ok(carList);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var car = await _carServices.GetAsync(id);
            if (car == null)
            {
               return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Car carmodel)
        {
            var car = await _carServices.CreateAsync(carmodel);

            if (car == null)
            {
               return BadRequest();
            }
            await _carServices.SaveAsync();
            return Ok(car);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var car = await _carServices.DeleteAsync(id);
            if(car == null)
            { 
                return NotFound();
            }

            await _carServices.SaveAsync(); 
            return Ok(car);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Car carModel)
        {
            if (carModel == null)
            {
                return BadRequest();
            }
            await _carServices.UpdateAsync(carModel);
            await _carServices.SaveAsync();

            return Ok(carModel);
        }
    }
}
