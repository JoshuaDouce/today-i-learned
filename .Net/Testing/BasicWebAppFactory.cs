public class MyApiTests
{
    private readonly WebApplicationFactory<YourStartupClass> _factory;

    public MyApiTests()
    {
        _factory = new WebApplicationFactory<YourStartupClass>();
    }

    [Fact]
    public async Task GetWeatherForecast_ReturnsSuccessStatusCode()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/weatherforecast");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}