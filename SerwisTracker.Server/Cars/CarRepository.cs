using Microsoft.EntityFrameworkCore;
using SerwisTracker.Server.Database;

namespace SerwisTracker.Server.Cars
{
    public interface ICarRepository
    {
        Task AddCarAsync(Car car);
        Task<Car> GetByLicensePlateAsync(string licensePlate, string userId);
    }

    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Car> _dbSet;

        public CarRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Car>();
        }

        public async Task AddCarAsync(Car car)
        {
            _dbSet.Add(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Car> GetByLicensePlateAsync(string licensePlate, string userId)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.LicensePlate == licensePlate && x.CreatorId == userId);
        }
    }
}
