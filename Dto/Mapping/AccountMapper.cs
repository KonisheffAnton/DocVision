using AutoMapper;
using DocVision.Business.Models;
using DocVision.Dto.Models;

namespace DocVision.Dto.Mapping
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<AccountBusinessModel, AccountDto>().ReverseMap();
        }
    }
}
