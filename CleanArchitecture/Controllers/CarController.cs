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
        private readonly IRepository<Car> _icarRepo;

        public CarController(ICarServices carServices, IRepository<Car> icarRepo)
        {
            _carServices = carServices;
            _icarRepo = icarRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carList = await _carServices.GetAll();
            return Ok(carList);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var car = await _carServices.GetById(id);
            if (car == null)
            {
               return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Car carmodel)
        {
            var car = await _carServices.Create(carmodel);

            if (car == null)
            {
               return BadRequest();
            }
            await _icarRepo.SaveChangesAsync();

            return Ok(car);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var car = await _carServices.Delete(id);
            if(car == null)
            { 
                return NotFound();
            }

            await _icarRepo.SaveChangesAsync(); 
            return Ok(car);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Car carModel)
        {
            if (carModel == null)
            {
                return BadRequest();
            }
            _carServices.Update(carModel);
            await _icarRepo.SaveChangesAsync();

            return Ok(carModel);
        }
    }
}
