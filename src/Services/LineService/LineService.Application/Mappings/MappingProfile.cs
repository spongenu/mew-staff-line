using System;
using AutoMapper;
using LineService.Application.Features.User.Queries.GetScheduleByIdToken;
using LineService.Domain.Entities;

namespace LineService.Application.Mappings
{
	public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StaffData, shift>();
        }
	}
}

