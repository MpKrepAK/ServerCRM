using AutoMapper;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Mapping.Entitys;

namespace CRM_Server_Side.Models.Mapping;

public class ShopMapper : Profile
{
    public ShopMapper() {
        CreateMap<Customer, RegistrationModel>();
        CreateMap<RegistrationModel, Customer>();
        CreateMap<Customer, LoginModel>();
        CreateMap<LoginModel, Customer>();
    }
}