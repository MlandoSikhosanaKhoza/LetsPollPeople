using AutoMapper;
using MeetingMinutes.DAL.Entities;
using MeetingMinutes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.BusinessLogic
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //User Mapping
            CreateMap<User, UserModel>().ForMember(u => u.Password, m => m.Ignore());
            CreateMap<UserModel, User>();

            //Meeting
            CreateMap<Meeting, MeetingModel>().ReverseMap();

            //Meeting Type
            CreateMap<MeetingType, MeetingTypeModel>().ReverseMap();

            //Meeting Item
            CreateMap<MeetingItem,MeetingItemModel>().ReverseMap();

            //Item
            CreateMap<Item, ItemModel>().ReverseMap();

            //Item Status
            CreateMap<ItemStatus, ItemStatusModel>().ReverseMap();

            //Status
            CreateMap<Status, StatusModel>().ReverseMap();

            //Role Mapping
            CreateMap<Role, RoleModel>().ReverseMap();

            //Option Mapping
            CreateMap<Option, OptionModel>()
                .ForMember(o => o.NumberOfVotes, m => m.MapFrom(o => o.UserVotes.Count()));
            CreateMap<OptionModel, Option>();

            //Question Mapping
            CreateMap<Question, QuestionModel>().ReverseMap();

            
        }
    }
}
