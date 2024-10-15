using AutoMapper;
using ToDo.BLL.Models.Dto;
using ToDo.DAL.Entity;
using ToDoApp.Models.Dto;

namespace ToDo.BLL.MappersProfiles;

public class ToDoItemProfile : Profile
{
    public ToDoItemProfile()
    {
        CreateMap<CreateToDoItemDto, ToDoItem>();
        CreateMap<ToDoItem, ReadToDoItemDto>();
        CreateMap<UpdateToDoItemDto, ToDoItem>();
    }
    
}