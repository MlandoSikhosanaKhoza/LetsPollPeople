using AutoMapper;
using LetsPollPeople.DAL.Entities;
using LetsPollPeople.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPollPeople.BusinessLogic
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //User Mapping
            CreateMap<User, UserModel>().ReverseMap();

            //Role Mapping
            CreateMap<Role, RoleModel>().ReverseMap();

            //Option Mapping
            CreateMap<Option, OptionModel>()
                .ForMember(o => o.NumberOfVotes, m => m.MapFrom(o => o.UserVote.Count()));
            CreateMap<OptionModel, Option>();

            //Question Mapping
            CreateMap<Question, QuestionModel>().ReverseMap();

            
        }
    }
}
