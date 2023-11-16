using Garage.Logic;
Console.OutputEncoding = System.Text.Encoding.Default;

var garage = new CarPark();
int parkingSpotNumber;
string licensePlate = "";
DateTime entryDate, exitDate;

Console.Clear();
Console.WriteLine("\nWelcome to the garage!");
Console.WriteLine("-------------------------");
Console.WriteLine("What do you want to do?");
Console.WriteLine("1) Enter a car entry\n2) Enter a car exit\n3) Generate report\n4) Exit");

while (true)
{
    Console.Write("\nYour selection: ");
    switch (Console.ReadLine()!)
    {
        case "1":
            Console.Write("Enter parking spot number: ");
            parkingSpotNumber = int.Parse(Console.ReadLine()!);
            if (garage.IsOccupied(parkingSpotNumber))
            {
                Console.WriteLine("Parking spot is occupied.");
                break;
            }
            Console.Write("Enter license plate: ");
            licensePlate = Console.ReadLine()!;
            Console.Write("Enter entry date: ");
            entryDate = DateTime.Parse(Console.ReadLine()!);
            garage.TryOccupy(parkingSpotNumber, licensePlate, entryDate);
            break;
        case "2":
            Console.Write("Enter parking spot number: ");
            parkingSpotNumber = int.Parse(Console.ReadLine()!);
            if (!garage.IsOccupied(parkingSpotNumber))
            {
                Console.WriteLine("Parking spot is not occupied.");
                break;
            }
            Console.Write("Enter exit date: ");
            exitDate = DateTime.Parse(Console.ReadLine()!);
            garage.TryExit(parkingSpotNumber, exitDate, out decimal costs);
            Console.WriteLine($"Costs are {costs}€");
            break;
        case "3":
            Console.WriteLine(garage.GenerateReport());
            break;
        case "4":
            Console.WriteLine("Goodbye!");
            return;
        default:
            Console.WriteLine("Please enter a valid number!");
            return;
    }

}

