using AutoMapper;
using linksproject.Models;
using links.Entities;

namespace linksproject
{
    public class MapingPostModel : Profile
    {
        public MapingPostModel()
        {
            CreateMap<CategoryPostModel, Category>().ReverseMap();
            CreateMap<UserPostModel, User>().ReverseMap();
            CreateMap<WebPostModel, Web>().ReverseMap();
        }
    }
}