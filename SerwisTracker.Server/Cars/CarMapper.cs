using SerwisTracker.Server.Extensions;
using SerwisTracker.Server.User;

namespace SerwisTracker.Server.Cars
{
    public class CarMapper
    {
        public static Car FormVmToCar(CarFormVm formVm, ApplicationUser creator)
        {
            return new Car
            {
                CarId = formVm.Id ?? 0,
                Brand = formVm.Brand.ToTitleCase(),
                Engine = formVm.Engine,
                LicensePlate = formVm.LicensePlate.ToUpper().Replace("-", "").Replace(" ", ""),
                ManufacturedYear = formVm.ManufacturedYear,
                Model = formVm.Model.ToTitleCase(),
                Creator = creator
            };
        }

        public static CarFormVm CarToFromVm(Car car)
        {
            return new CarFormVm
            {
                Id = car.CarId,
                Brand = car.Brand,
                Engine = car.Engine,
                LicensePlate = car.LicensePlate,
                ManufacturedYear = car.ManufacturedYear,
                Model = car.Model
            };
        }
    }
}
