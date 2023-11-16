namespace Garage.Logic;

public class ParkingSpot
{
    public ParkingSpot(string licensePlate, DateTime entryDate)
    {
        LicensePlate = licensePlate;
        EntryDate = entryDate;
    }
    public string LicensePlate { get; set; } = "";
    public DateTime EntryDate { get; set; }
}

