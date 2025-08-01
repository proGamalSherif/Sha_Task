using System.Application.DTOs.InvoiceDTOs;
using System.Domain.Entities;
using AutoMapper;

namespace System.Application.MappingProfiles
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<InvoiceHeader, ReadInvoiceDTO>()
                .ForMember(dest=>dest.CashierName,opt=>opt.MapFrom(src=>src.Cashier.CashierName))
                .ForMember(dest=>dest.BranchName,opt=>opt.MapFrom(src=>src.Branch.BranchName))
                .ReverseMap();
            CreateMap<InvoiceHeader, InsertInvoiceDTO>()
                .ReverseMap();
            CreateMap<InvoiceHeader, UpdateInvoiceDTO>()
                .ReverseMap();

            CreateMap<InvoiceDetails, ReadInvoiceDetailsDTO>()
                .ReverseMap();
            CreateMap<InvoiceDetails, InsertInvoiceDetailsDTO>()
                .ReverseMap();
        }
    }
}
