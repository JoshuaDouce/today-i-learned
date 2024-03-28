using Xunit;

// The IClassFixture<T> interface is used to define a class fixture.
// It allows you to share the same instance of a class across multiple test methods or test classes.
// This can be useful when you need to set up some expensive or time-consuming resources that can be reused by multiple tests.
public class MyTestFixture : IClassFixture<MyClassFixture>
{
    private readonly MyClassFixture _fixture;

    public MyTestFixture(MyClassFixture fixture)
    {
        _fixture = fixture;
        // Additional setup code for the fixture can be added here
    }

    [Fact]
    public void MyTest()
    {
        // Use the shared instance of MyClassFixture in your test
        // ...
    }

    // Additional test methods can be added here
}

// The class that implements IClassFixture<T> will be instantiated once for all the tests that use it.
public class MyClassFixture
{
    // Add any setup code or resources that need to be shared across tests here
    // ...
}