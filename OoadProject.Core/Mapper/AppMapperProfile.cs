using AutoMapper;
using OoadProject.Core.ViewModels.Home.Dto;
using OoadProject.Data.Entity.AppProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<Order, ProcessingOrderDto>()
                .ForMember(dest => dest.CreatedUser, opt =>
                    opt.MapFrom(src => src.CreationUser.Name))
                .ForMember(dest => dest.ProviderName, opt =>
                    opt.MapFrom(src => src.Provider.Name))
                .ForMember(dest => dest.Status, opt =>
                    opt.MapFrom(src => ProcessingOrderDto.MapEnumToStatus((OrderStatus)src.Status)));
        }
    }
}
