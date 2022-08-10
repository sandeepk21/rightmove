using AutoMapper;
using RightMoveADF.Models;
using RightMoveADF.ViewModels;
using System.Dynamic;
namespace RightMoveADF.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PropertyViewModel,Property>().ReverseMap();
            CreateMap<PropertyAddressViewModel, PropertyAddress>().ReverseMap();
            CreateMap<PropertyDetailsSizingViewModel, PropertyDetailsSizing>().ReverseMap();
            CreateMap<PropertyDetailViewModel, PropertyDetail>().ReverseMap();
            CreateMap<PropertyMediaViewModel, PropertyMedia>().ReverseMap();
            CreateMap<PropertyPriceViewModel, PropertyPrice>().ReverseMap();
            CreateMap<PropertyRoomViewModel, PropertyRoom>().ReverseMap();

        }
    }
}
