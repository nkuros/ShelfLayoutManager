namespace ShelfLayoutManager.Helpers;

using AutoMapper;
using ShelfLayoutManager.Entities;
using ShelfLayoutManager.Models;

{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCabinetRequest, Cabinet>();
            CreateMap<CreateRowRequest, Row>();
            CreateMap<CreateLaneRequest, Lane>();
            CreateMap<UpdateCabinetRequest, Cabinet>();
            CreateMap<UpdateRowRequest, Row>();
            CreateMap<UpdateLaneRequest, Lane>();
        }
    }
}