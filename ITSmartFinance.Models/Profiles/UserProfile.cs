using AutoMapper;
using ITSmartFinance.Models.Models;
using ITSmartFinanceTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSmartFinance.Models.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            //Профиль маппинга пользователя
            CreateMap<UserCreateModel, User>()
              .ForMember(b => b.Name, model => model.MapFrom(src => src.Name));
            CreateMap<UserUpdateModel, User>()
                .ForMember(b => b.Name, model => model.MapFrom(src => src.Name))
                .ForMember(b => b.Id, model => model.MapFrom(src => src.Id));
        }
    }
}
