using AutoMapper;
using DocVision.Business.Models;
using DocVision.Dto.Models;

namespace DocVision.Dto.Mapping
{
    public class MailMapper : Profile
    {
        public MailMapper()
        {
            CreateMap<MailDto, MailBusinessModel>().ReverseMap();
        }
    }
}
