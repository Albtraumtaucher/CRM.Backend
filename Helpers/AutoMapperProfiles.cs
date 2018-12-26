using System;
using AutoMapper;
using CRM.API.Dtos;
using CRM.API.Models;

namespace CRM.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Maps for Users
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<User, UserForRegisterDto>();
            CreateMap<UserForRegisterDto, User>();

            //Maps for Leads
            CreateMap<Lead, LeadForListDto>();
            CreateMap<LeadToCreateDto, Lead>();

            //Maps for LeadStatus
            CreateMap<LeadStatusToUpdateDto, LeadStatus>();
            CreateMap<LeadStatus, LeadStatusToReturnDto>();
        }
    }
}