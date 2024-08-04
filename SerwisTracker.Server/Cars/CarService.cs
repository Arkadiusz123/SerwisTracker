using SerwisTracker.Server.Shared;

namespace SerwisTracker.Server.Cars
{
    public interface ICarService
    {
        Task<ValueResult<Car>> AddCarAsync(Car car);
    }

    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValueResult<Car>> AddCarAsync(Car car)
        {
            var carWithLicensePlate = await _repository.GetByLicensePlateAsync(car.LicensePlate, car.Creator.Id);

            if (carWithLicensePlate != null)
                return new ValueResult<Car>(false, "Samochód o podanym numerze rejestracyjnym już istnieje");

            await _repository.AddCarAsync(car);
            return new ValueResult<Car>(car, true);
        }
    }
}
