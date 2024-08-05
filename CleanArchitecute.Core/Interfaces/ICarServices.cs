
using CleanArchitecute.Core.Entities;

namespace CleanArchitecute.Core.Interfaces
{
    public interface ICarServices : IRepository<Car>
    {
        public Task<int> SaveAsync();
        public Task<Car?> UpdateAsync(Car car);

    }
}
