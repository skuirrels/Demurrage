namespace Demurrage.UnitTests;

public class PortDemurrageCalculatorTests
{
    [Fact]
    public void CalculateDemurrageDetails_WithValidDates_ShouldCalculateCorrectly()
    {
        // Arrange
        var fclUnloaded = DateTime.MinValue;
        var arrived = new DateTime(2023, 11, 02);
        var fclWharfGateOut = new DateTime(2023, 11, 20);
        var actualFullDelivery = DateTime.MinValue;
        var fullLoadPortFreeTime = 5;

        // Expected demurrage start date is 5 days after 'arrived' date
        var expectedDemurrageStartDate = arrived.AddDays(fullLoadPortFreeTime);
        // Expected gate out date is 'fclWharfGateOut'
        var expectedGateOutDate = fclWharfGateOut;
        // Expected days on demurrage
        var expectedDaysOnDemurrage = (expectedGateOutDate - expectedDemurrageStartDate).Days;

        // Act
        var result = PortDemurrageCalculator.CalculateDemurrageDetails(
            fclUnloaded,
            arrived,
            fclWharfGateOut,
            actualFullDelivery,
            fullLoadPortFreeTime);

        // Assert
        Assert.Equal(expectedDemurrageStartDate, result.DemurrageStartDate);
        Assert.Equal(expectedGateOutDate, result.GateOutDate);
        Assert.Equal(expectedDaysOnDemurrage, result.DaysOnDemurrage);
    }

    [Fact]
    public void CalculateDemurrageDetails_WithGateOutBeforeDemurrageStart_ShouldHaveNoDemurrage()
    {
        // Arrange
        var fclUnloaded = DateTime.MinValue;
        var arrived = new DateTime(2023, 11, 02);
        var fclWharfGateOut = new DateTime(2023, 11, 06); // Before demurrage would start
        var actualFullDelivery = DateTime.MinValue;
        var fullLoadPortFreeTime = 5;

        // Expected days on demurrage should be 0 since gate out is before demurrage start
        var expectedDaysOnDemurrage = 0;

        // Act
        var result = PortDemurrageCalculator.CalculateDemurrageDetails(
            fclUnloaded,
            arrived,
            fclWharfGateOut,
            actualFullDelivery,
            fullLoadPortFreeTime);

        // Assert
        Assert.Equal(expectedDaysOnDemurrage, result.DaysOnDemurrage);
    }
}
