namespace ShelfLayoutManager.Helpers;

using AutoMapper;
using ShelfLayoutManager.Entities;
using ShelfLayoutManager.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CabinetModel, Cabinet>();
        CreateMap<RowModel, Row>();
            // .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Size.Height))
            // .ReverseMap();
        CreateMap<LaneModel, Lane>();
        CreateMap<PositionModel, Position>();
        CreateMap<SizeModel, Size>();
    }
}
