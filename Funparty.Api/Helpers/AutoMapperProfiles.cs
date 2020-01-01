using AutoMapper;
using Funparty.Api.Application.Dtos;
using Funparty.Api.Domain.Entities;

namespace Funparty.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Mascot, MascotDto>();
        }
    }
}
