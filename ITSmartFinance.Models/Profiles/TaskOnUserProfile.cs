using AutoMapper;
using ITSmartFinance.Models.Models;
using ITSmartFinanceTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSmartFinance.Models.Profiles
{
    public class TaskOnUserProfile:Profile
    {
        public TaskOnUserProfile()
        {
            //Профиль маппинга таблицы связи 
            CreateMap<RelationCreateModel, TaskOnUser>()
                .ForMember(b => b.TaskId, model => model.MapFrom(src => src.TaskId))
                .ForMember(b => b.UserId, model => model.MapFrom(src => src.UserId));
        }
    }
}
