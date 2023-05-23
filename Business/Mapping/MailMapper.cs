using AutoMapper;
using DocVision.Business.Models;
using DocVision.DataAccessLayer.Entities;

namespace DocVision.Business.Mapping
{
    public class MailMapper : Profile
    {
        public MailMapper()
        {
            CreateMap<MailEntity, MailBusinessModel>()
                .ReverseMap();
        }
    }
}
