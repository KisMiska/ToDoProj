
using Application.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ToDo.Core.Models;
using ToDo.Core.Models.Enums;

namespace ToDo.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItem, GetToDoItemDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description));
            CreateMap<CreateToDoItemDTO, ToDoItem>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => Status.ToDo));
            CreateMap<UpdateToDoTitemDTO, ToDoItem>();
        }
    }
}
