﻿using AutoMapper;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Mappings
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRoleDto, UserRole>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId)).ReverseMap();

            CreateMap<Role, UserRole>().ForMember(d => d.RoleId, opt => opt.MapFrom(s => s.Id)).ForMember(d => d.Id, opt => opt.Ignore()).ReverseMap();


            CreateMap<UserRoleDto, IEnumerable<UserRole>>().ConvertUsing<GetFromRoleIds>();
        }
    }
    public class GetFromRoleIds : ITypeConverter<UserRoleDto, IEnumerable<UserRole>>
    {
        public IEnumerable<UserRole> Convert(UserRoleDto source, IEnumerable<UserRole> destination, ResolutionContext context)
        {

            foreach (var model in source.Roles.Select(e => context.Mapper.Map<UserRole>(e)))
            {
                context.Mapper.Map(source, model);
                yield return model;
            }


        }
    }
}
