namespace ToDoList.Bll.Services;

public class EvenSumContext
{
    private readonly ISummOfEvenNumbers _strategy;

    public EvenSumContext(EvenSumStrategyResolver resolver)
    {
        _strategy = resolver.ResolveStrategy();
    }

    public int ExecuteStrategy(List<int> numbers)
    {
        return _strategy.SummOfEvenNumbers(numbers);
    }
}
