using Xunit;

// Define the collection fixture
public class MyCollectionFixture : ICollectionFixture<MyDatabaseFixture>
{
    // This class will be instantiated once per test collection
    // and shared across all the tests within the collection.
    // You can use it to set up and tear down expensive resources
    // that need to be shared across multiple tests.
}

// Use the collection fixture in a test class
[Collection("MyCollection")]
public class MyTestClass
{
    private readonly MyDatabaseFixture _databaseFixture;

    public MyTestClass(MyCollectionFixture collectionFixture)
    {
        // The collection fixture will be injected into the test class constructor.
        // You can use it to access the shared resources.
        _databaseFixture = collectionFixture.DatabaseFixture;
    }

    [Fact]
    public void Test1()
    {
        // Use the shared resources in your test
        // ...
    }

    [Fact]
    public void Test2()
    {
        // Use the shared resources in your test
        // ...
    }
}