
using CleanArchitecute.Core.Entities;

namespace CleanArchitecute.Core.Interfaces
{
    public interface ICarServices
    {
        Task<Car?> Create(Car car); 
        Task<IEnumerable<Car>> GetAll();    
        Task<Car?> GetById(int carId);
        Task<Car?> Delete(int carId);
        void Update(Car car);
    }
}
