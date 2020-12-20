using AutoMapper;
using OoadProject.Core.ViewModels.Home.Dtos;
using OoadProject.Core.ViewModels.Orders.Dtos;
using OoadProject.Core.ViewModels.Settings.Dtos;
using OoadProject.Core.ViewModels.Sells.Dtos;
using OoadProject.Core.ViewModels.Users.Dtos;
using OoadProject.Data.Entity.AppProduct;
using OoadProject.Data.Entity.AppUser;
using OoadProject.Data.Repository.AggregateDto;
using OoadProject.Data.Entity.AppCustomer;
using OoadProject.Core.ViewModels.Warranties.Dtos;
using System;

namespace OoadProject.Core
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            // Dto for home
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

            // User
            CreateMap<UserForCreationDto, User>()
                .ForMember(dest => dest.Role, opt =>
                    opt.Ignore())
                .ForMember(dest => dest.RoleId, opt =>
                    opt.Ignore())
                .ForMember(dest => dest.Id, opt =>
                    opt.Ignore());
            CreateMap<User, UserForCreationDto>()
                .ForMember(dest => dest.Role, opt =>
                    opt.MapFrom(src => src.Role.Name));

            // Product for order
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
            CreateMap<OrderProduct, ProductForOrderListDto>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.Product.Id))
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.CategoryName, opt =>
                    opt.MapFrom(src => src.Product.Category.Name));

            // Product for sell
            CreateMap<Product, ProductForSellDto>()
                .ForMember(dest => dest.CategoryName, opt =>
                    opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ManufacturerName, opt =>
                    opt.MapFrom(src => src.Manufacturer.Name));
            CreateMap<ProductForSellDto, SelectingProductForSellDto>()
                .ForMember(dest => dest.SelectedNumber, opt =>
                    opt.MapFrom(src => 1));

            // Provider
            CreateMap<ProviderForCreationDto, Provider>();

            // Manufacturer
            CreateMap<ManufacturerForCreationDto, Manufacturer>();

            // Category
            CreateMap<CategoryForCreationDto, Category>();

            // Warranty
            CreateMap<InvoiceProduct, ProductForWarrantyDto>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ManufacturerName, opt =>
                    opt.MapFrom(src => src.Product.Manufacturer.Name))
                .ForMember(dest => dest.InvoiceTime, opt =>
                    opt.MapFrom(src => src.Invoice.CreationTime))
                .ForMember(dest => dest.WarrantyTimeRemaining, opt =>
                    opt.MapFrom(src => ProductForWarrantyDto.CalcWarrantyMonthRemaining(src.Invoice.CreationTime, (int)src.Product.WarrantyPeriod)))
                .ForMember(dest => dest.CustomerName, opt => 
                    opt.MapFrom(src => src.Invoice.Customer.Name))
                .ForMember(dest => dest.PhoneNumber, opt =>
                    opt.MapFrom(src => src.Invoice.Customer.PhoneNumber))
                .ForMember(dest => dest.CustomerId, opt =>
                    opt.MapFrom(src => src.Invoice.CustomerId))
                .ForMember(dest => dest.InvoiceId, opt =>
                    opt.MapFrom(src => src.InvoiceId));
            CreateMap<ProductForWarrantyDto, WarrantyOrder>()
                .ForMember(dest => dest.ProductId, opt =>
                    opt.MapFrom(src => src.Id));
            CreateMap<WarrantyOrder, ProductForListWarrantyDto>()
                .ForMember(dest => dest.CustomerName, opt =>
                    opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.PhoneNumber, opt =>
                    opt.MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.ProductName, opt =>
                    opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.WarrantyStatus, opt =>
                    opt.MapFrom(src => src.Status));
            CreateMap<ProductForListWarrantyDto, WarrantyOrder>()
                .ForMember(dest => dest.Status, opt =>
                    opt.MapFrom(src => src.WarrantyStatus));

            // Order
            CreateMap<Order, OrderForListDto>()
                .ForMember(dest => dest.CreationUser, opt =>
                    opt.MapFrom(src => src.CreationUser.Name))
                .ForMember(dest => dest.ProviderName, opt =>
                    opt.MapFrom(src => src.Provider.Name));
        }
    }
}
