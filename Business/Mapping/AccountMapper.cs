using AutoMapper;
using DocVision.Business.Models;
using DocVision.DataAccessLayer.Entities;

namespace DocVision.Business.Mapping
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<AccountEntity, AccountBusinessModel>()
                .ReverseMap();
        }
    }
}
