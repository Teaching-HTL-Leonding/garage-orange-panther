namespace Garage.Logic;
public class CarPark
{
    public ParkingSpot[] ParkingSpots { get; } = new ParkingSpot[50];

    public bool IsOccupied(int parkingSpotNumber)
    {
        if (ParkingSpots[parkingSpotNumber - 1] == null)
        {
            return false;
        }
        return true;
    }

    public bool TryOccupy(int parkingSpotNumber, string licensePlate, DateTime entryDate)
    {
        if (IsOccupied(parkingSpotNumber)) { return false; }
        ParkingSpots[parkingSpotNumber - 1] = new ParkingSpot(licensePlate, entryDate);
        return true;
    }

    public bool TryExit(int parkingSpotNumber, DateTime exitDate, out decimal costs)
    {
        costs = 0;

        // if the parking spot i occupied, we exit
        if (!IsOccupied(parkingSpotNumber)) { return false; }

        // calculate the total parking time in minutes
        double parkingTime = (exitDate - ParkingSpots[parkingSpotNumber - 1].EntryDate).TotalMinutes;

        // if car leaves within 15 minutes
        if ((int)parkingTime <= 15) { return true; }

        // you pay for every started half our
        costs = (int)parkingTime / 30 * 3;
        if (parkingTime % 30 != 0) { costs += 3; }

        // set the parking spot to not occupied again
        ParkingSpots[parkingSpotNumber - 1] = null!;
        return true;
    }

    public string GenerateReport()
    {
        string report = "| Spot | License Plate |\n| ---- | ------------- |\n";
        for (int i = 0; i < ParkingSpots.Length; i++)
        {
            report += $"| {i + 1,-4} | {ParkingSpots[i]?.LicensePlate,-13} |\n";
        }
        return report;
    }
}