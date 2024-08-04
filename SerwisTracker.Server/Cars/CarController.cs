using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerwisTracker.Server.User;

namespace SerwisTracker.Server.Cars
{
    [ApiController]
    [Route("api/cars")]
    [Authorize]
    public class CarController : ControllerBase
    {
        public readonly ICarService _carService;
        public readonly IUserService _userService;

        public CarController(ICarService carService, IUserService userService)
        {
            _carService = carService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> AddCar([FromBody]CarFormVm car)
        {
            var userResult = _userService.GetByName(User.Identity.Name);

            if (!userResult.Success)
                return NotFound(userResult.Message);

            var carEntity = CarMapper.FormVmToCar(car, userResult.Value);
            var addResult = await _carService.AddCarAsync(carEntity);

            if (!addResult.Success)
                return BadRequest(addResult.Message);

            return Ok(addResult.Value);
        }
    }
}
