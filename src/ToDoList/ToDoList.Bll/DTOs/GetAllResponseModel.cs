namespace ToDoList.Bll.DTOs;

public class GetAllResponseModel
{
    public int TotalCount { get; set; }
    public List<ToDoItemGetDto> ToDoItemGetDtos { get; set; }
}
