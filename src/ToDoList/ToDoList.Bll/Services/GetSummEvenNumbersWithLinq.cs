namespace ToDoList.Bll.Services;

public class GetSummEvenNumbersWithLinq : ISummOfEvenNumbers
{
    public int SummOfEvenNumbers(List<int> nums)
    {
        return nums.Where(n => n % 2 == 0).Sum();
    }
}
