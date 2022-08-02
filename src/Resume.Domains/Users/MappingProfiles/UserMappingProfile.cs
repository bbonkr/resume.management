using System;
using AutoMapper;
using Resume.Domains.Users.Models;
using Resume.Entities;

namespace Resume.Domains.Users.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserModel>();
    }
}

