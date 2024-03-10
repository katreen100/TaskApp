

using AutoMapper;
using TaskApp.core.DTOS;
using TaskApp.core.model;

namespace TaskApp.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<TaskDto, Taskmodel>();
            CreateMap<Taskmodel, TaskDto>();
        }
    }
}
