using AutoMapper;
using ITSmartFinance.Models.Models;
using ITSmartFinanceTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSmartFinance.Models.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            //Профиль маппинг задачки
            CreateMap<TaskCreateModel, Task>()
                .ForMember(b => b.Description, model => model.MapFrom(src => src.Description))
                .ForMember(b => b.CreatedTime, model => model.MapFrom(src => DateTime.Now))
                .ForMember(b => b.BoardId, model => model.MapFrom(src => src.BoardId));
            CreateMap<TaskUpdateModel, Task>()
                .ForMember(b => b.Description, model => model.MapFrom(src => src.Description))
                .ForMember(b => b.BoardId, model => model.MapFrom(src => src.BoardId))
                .ForMember(b => b.Id, model => model.MapFrom(src => src.Id));
        }
    }
}
