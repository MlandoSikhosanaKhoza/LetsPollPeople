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
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
