using AutoMapper;
using ITSmartFinance.Models.Models;
using ITSmartFinanceTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSmartFinance.Models.Profiles
{
    public class BoardProfile :Profile
    {
        public BoardProfile()
        {
            //Профиль маппинга доски
            CreateMap<BoardCreateModel, Board>()
                .ForMember(b => b.Description, model => model.MapFrom(src => src.Description));
            CreateMap<BoardUpdateModel, Board>()
                .ForMember(b => b.Description, model => model.MapFrom(src => src.Description))
                .ForMember(b => b.Id, model => model.MapFrom(src => src.Id));
        }
    }
}
