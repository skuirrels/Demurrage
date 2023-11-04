
namespace Demurrage;

public class PortDemurrageCalculator
{
    public int FullLoadPortFreeTime { get; set; } 

    public class DemurrageResult
    {
        public DateTime AvailableDate { get; set; }
        public DateTime DemurrageStartDate { get; set; }
        public DateTime GateOutDate { get; set; }
        public int DaysOnDemurrage { get; set; }
    }

    public static DemurrageResult CalculateDemurrageDetails(
        DateTime fclUnloaded,
        DateTime arrived,
        DateTime fclWharfGateOut,
        DateTime actualFullDelivery,
        int fullLoadPortFreeTime) 
    {
        DateTime availableDate = fclUnloaded != DateTime.MinValue ? fclUnloaded 
            : arrived != DateTime.MinValue ? arrived 
            : DateTime.MinValue;

        DateTime demurrageStartDate = availableDate != DateTime.MinValue ? availableDate.AddDays(fullLoadPortFreeTime) : DateTime.MinValue;

        DateTime gateOutDate = fclWharfGateOut != DateTime.MinValue ? fclWharfGateOut 
            : actualFullDelivery != DateTime.MinValue ? actualFullDelivery 
            : DateTime.Now;

        TimeSpan demurrageTimeSpan = gateOutDate - demurrageStartDate;

        return new DemurrageResult
        {
            AvailableDate = availableDate,
            DemurrageStartDate = demurrageStartDate,
            GateOutDate = gateOutDate,
            DaysOnDemurrage = demurrageTimeSpan.Days
        };
    }
}