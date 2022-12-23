using AutoMapper;
using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey_Project.Service.Mapping
{
    public class MapProfiles:Profile
    {
        public MapProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
        }
    }
}
