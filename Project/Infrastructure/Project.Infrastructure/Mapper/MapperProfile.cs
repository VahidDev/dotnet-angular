using AutoMapper;
using Project.Core.Entities;
using Project.Infrastructure.Dtos;

namespace Project.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Rectangle,RectangleDto>().ReverseMap();
        }
    }
}
