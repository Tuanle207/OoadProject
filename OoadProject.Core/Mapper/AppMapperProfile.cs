using AutoMapper;
using OoadProject.Core.ViewModels.Home.Dtos;
using OoadProject.Core.ViewModels.Orders.Dtos;
using OoadProject.Core.ViewModels.Providers.Dtos;
using OoadProject.Core.ViewModels.Sells.Dtos;
using OoadProject.Core.ViewModels.Users.Dtos;
using OoadProject.Data.Entity.AppProduct;
using OoadProject.Data.Entity.AppUser;
using OoadProject.Data.Repository.AggregateDto;

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

            CreateMap<ProductAggregateDto, HotProductDto>()
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ManufacturerName, opt =>
                    opt.MapFrom(src => src.Product.Manufacturer.Name))
                .ForMember(dest => dest.Sales, opt =>
                    opt.MapFrom(src => src.SalesNo));

            CreateMap<UserForCreationDto, User>()
                .ForMember(dest => dest.Role, opt =>
                    opt.Ignore())
                .ForMember(dest => dest.RoleId, opt =>
                    opt.Ignore());

            CreateMap<Product, ProductForOrderCreationDto>()
                .ForMember(dest => dest.CategoryName, opt =>
                    opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ManufacturerName, opt =>
                    opt.MapFrom(src => src.Manufacturer.Name));

            CreateMap<ProductForOrderCreationDto, SelectingProductDto>();

            CreateMap<OrderForCreationDto, Order>()
                .ForMember(dest => dest.Status, opt =>
                    opt.MapFrom(src => (int)OrderStatus.WaitForSent));

            CreateMap<SelectingProductDto, OrderProduct>()
                .ForMember(dest => dest.ProductId, opt =>
                    opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Number, opt =>
                    opt.MapFrom(src => src.SelectedNumber));

            CreateMap<Product, ProductForSellDto>()
                .ForMember(dest => dest.CategoryName, opt =>
                    opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ManufacturerName, opt =>
                    opt.MapFrom(src => src.Manufacturer.Name));

            CreateMap<ProductForSellDto, SelectingProductForSellDto>()
                .ForMember(dest => dest.SelectedNumber, opt =>
                    opt.MapFrom(src => 1));

            //Provider
            CreateMap<ProviderForCreationDto, Provider>();
        }
    }
}
