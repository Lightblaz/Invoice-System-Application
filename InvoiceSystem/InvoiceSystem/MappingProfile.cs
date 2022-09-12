using AutoMapper;
using DAL.Models;
using DAL.ViewModels;

namespace InvoiceSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerVm>();
            CreateMap<CustomerVm, Customer>();
        }
    }
}
