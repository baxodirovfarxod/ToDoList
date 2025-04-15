using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.Bll.Services;

public class EvenSumStrategyResolver
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;

    public EvenSumStrategyResolver(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }

    public ISummOfEvenNumbers ResolveStrategy()
    {
        var strategyName = _configuration["EvenSum:Strategy"]?.ToLower();

        return strategyName switch
        {
            "for" => _serviceProvider.GetRequiredService<GetSummEvenNumbersWithFor>(),
            "foreach" => _serviceProvider.GetRequiredService<GetSummEvenNumbersWithForeach>(),
            "linq" => _serviceProvider.GetRequiredService<GetSummEvenNumbersWithLinq>(),
            _ => throw new InvalidOperationException("Invalid strategy configured")
        };
    }

}
