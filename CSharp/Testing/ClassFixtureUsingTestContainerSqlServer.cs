using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
using TestContainers.Containers;
using TestContainers.Containers.Builders;
using TestContainers.Containers.Modules;

public class SqlServerFixture : IAsyncLifetime
{
    private readonly MSSqlServerContainer _container;

    public string ConnectionString { get; private set; }

    public SqlServerFixture()
    {
        _container = new MSSqlServerContainerBuilder()
            .WithDatabaseName("testdb")
            .WithUsername("sa")
            .WithPassword("P@ssw0rd")
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();
        ConnectionString = _container.GetConnectionString();
    }

    public async Task DisposeAsync()
    {
        await _container.StopAsync();
    }
}

public class MyTestClass : IClassFixture<SqlServerFixture>
{
    private readonly SqlServerFixture _fixture;
    private readonly ITestOutputHelper _output;

    public MyTestClass(SqlServerFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _output = output;
    }

    [Fact]
    public async Task MyTest()
    {
        // Use the SQL Server connection string from the fixture
        _output.WriteLine($"Connection String: {_fixture.ConnectionString}");

        // Your test code here
        // Example: Assert something about the database state
        // Example: Insert test data and verify the results

        await Task.Delay(100); // Simulate some async operation
    }
}