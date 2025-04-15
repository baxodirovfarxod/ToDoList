namespace ToDoList.Bll.Services;

public class GetSummEvenNumbersWithForeach : ISummOfEvenNumbers
{
    public int SummOfEvenNumbers(List<int> nums)
    {
        var summ = 0;
        foreach (var item in nums)
        {
            summ += item % 2 == 0 ? item : 0;
        }

        return summ;
    }
}
