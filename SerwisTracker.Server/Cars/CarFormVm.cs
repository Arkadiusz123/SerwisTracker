namespace SerwisTracker.Server.Cars
{
    public class CarFormVm
    {
        public int? Id { get; set; }
        public required string LicensePlate { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required string Engine { get; set; }
        public required int ManufacturedYear { get; set; }
    }
}
