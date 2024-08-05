using CleanArchitecture.Infrastructure.Presistence;
using CleanArchitecture.Infrastructure.Presistence.Data;
using CleanArchitecute.Core.Entities;
using CleanArchitecute.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Services
{
    public class CarServices : Repository<Car>, ICarServices
    {
        
        private readonly ApplicationDbContext _context;

        public CarServices(ApplicationDbContext context) : base(context) 
        {
            _context = context; 
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Car?> UpdateAsync(Car car)
        {
            var carModel = await _context.Cars.FirstOrDefaultAsync(c => c.Id == car.Id);
            if (carModel == null)
                return null;

            carModel.Id = car.Id;
            carModel.Name = car.Name;
            carModel.Description = car.Description;

            return car;

        }
    }
}
