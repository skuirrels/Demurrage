
using Demurrage;

class Program
{
    static void Main(string[] args)
    {
        var fullLoadPortFreeTime = 5; // This could be set based on some logic or configuration

        var result = PortDemurrageCalculator.CalculateDemurrageDetails(
            DateTime.MinValue,                  // FCL Unloaded Date
            new DateTime(2023, 11, 02),        // Arrived Date
            new DateTime(2023, 11, 20),        // FCL Wharf Gate Out Date
            DateTime.MinValue,                 // Actual Full Delivery Date
            fullLoadPortFreeTime               // Full Load Port Free Time
        );

        Console.WriteLine($"Available Date: {result.AvailableDate}");
        Console.WriteLine($"Port Free-Time: {fullLoadPortFreeTime} Days");
        Console.WriteLine($"Demurrage Start Date: {result.DemurrageStartDate}");
        Console.WriteLine($"Gate Out Date: {result.GateOutDate}");
        Console.WriteLine($"Days on demurrage: {result.DaysOnDemurrage}");
    }
}