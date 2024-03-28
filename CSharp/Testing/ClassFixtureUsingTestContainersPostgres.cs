using System;
using System.Threading.Tasks;
using Xunit;
using TestContainers.Containers.PostgreSql;

public class PostgresContainerFixture : IAsyncLifetime
{
    private PostgreSqlContainer _container;

    public string ConnectionString { get; private set; }

    public async Task InitializeAsync()
    {
        _container = new PostgreSqlContainer("postgres:latest")
        {
            PortBindings = { { "5432", "5432" } },
            Password = "mysecretpassword"
        };

        await _container.StartAsync();

        ConnectionString = _container.GetConnectionString();
    }

    public async Task DisposeAsync()
    {
        await _container.StopAsync();
        _container.Dispose();
    }
}

public class ClassFixtureUsingTestContainersPostgres : IClassFixture<PostgresContainerFixture>
{
    private readonly PostgresContainerFixture _fixture;

    public ClassFixtureUsingTestContainersPostgres(PostgresContainerFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task TestUsingPostgresContainer()
    {
        // Use _fixture.ConnectionString to connect to the Postgres container and perform tests
        Console.WriteLine($"Connection string: {_fixture.ConnectionString}");

        // Your test logic here
        // Example:
        // using (var connection = new NpgsqlConnection(_fixture.ConnectionString))
        // {
        //     await connection.OpenAsync();
        //     // Perform database operations
        // }
    }
}