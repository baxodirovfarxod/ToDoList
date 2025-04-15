
namespace ToDoList.Bll.Services;

public class GetSummEvenNumbersWithFor : ISummOfEvenNumbers
{
    public int SummOfEvenNumbers(List<int> nums)
    {
        var summ = 0;
        for (int i = 0; i < nums.Count; i++)
        {
            if (nums[i] % 2 == 0)
            {
                summ += nums[i];
            }
        }

        return summ;
    }
}
