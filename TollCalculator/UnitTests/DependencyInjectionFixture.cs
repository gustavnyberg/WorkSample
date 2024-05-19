namespace TollCalculator.UnitTests;

using Library.Services.Calculator;
using Microsoft.Extensions.DependencyInjection;

public class DependencyInjectionFixture
{
    public ServiceProvider ServiceProvider { get; }
    public DependencyInjectionFixture()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<ITollCalculator, TollCalculator>();
        // Add other services
        ServiceProvider = serviceCollection.BuildServiceProvider();
    }
}