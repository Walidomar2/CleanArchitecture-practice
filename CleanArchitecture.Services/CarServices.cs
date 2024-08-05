using CleanArchitecute.Core.Entities;
using CleanArchitecute.Core.Interfaces;

namespace CleanArchitecture.Services
{
    public class CarServices : ICarServices
    {
        private readonly IRepository<Car> _carRepo;

        public CarServices(IRepository<Car> carRepo)
        {
            _carRepo = carRepo;
        }

        public async Task<Car?> Create(Car car)
        {
            return await _carRepo.CreateAsync(car); 
        }

        public async Task<Car?> Delete(int carId)
        {
            return await _carRepo.DeleteAsync(carId);
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _carRepo.GetAllAsync();   
        }

        public async Task<Car?> GetById(int carId)
        {
            return await _carRepo.GetAsync(carId);
        }

        public void Update(Car car)
        {
            _carRepo.UpdateAsync(car);
        }
    }
}
