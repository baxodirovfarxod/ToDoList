using AutoMapper;
using ToDoList.Bll.DTOs;
using ToDoList.Dal.Entity;

namespace ToDoList.Bll.ProFile;

public class MappingProFile : Profile
{
    public MappingProFile()
    {
        CreateMap<ToDoItem, ToDoItemCreateDto>().ReverseMap();
        CreateMap<ToDoItem, ToDoItemGetDto>().ReverseMap();
        CreateMap<ToDoItem, ToDoItemUpdateDto>().ReverseMap();
    }
}

