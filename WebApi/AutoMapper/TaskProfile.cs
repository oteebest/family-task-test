using AutoMapper;
using Domain.Commands;
using Domain.DataModels;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.AutoMapper
{

    public class TaskProfile : Profile
    {
        public TaskProfile()
        {

            CreateMap<Task, TaskVm>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TaskId))
           .ForMember(dest => dest.AssignedMemberId, opt =>
            opt.MapFrom(src => src.Member.MemberId));
        }
    }
}
