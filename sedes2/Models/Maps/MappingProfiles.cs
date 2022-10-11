using AutoMapper;
using Microsoft.AspNetCore.OData.Deltas;
using sedes.Models.Frontend;

namespace sedes.Models.Maps
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ZSeat, Seat>().ReverseMap();
            CreateMap<ZRoom, Room>().ReverseMap();
            CreateMap<ZBuilding, Building>().ReverseMap();
            CreateMap<Delta<ZSeat>, Delta<Seat>>(); 
            
        }
    }
}
