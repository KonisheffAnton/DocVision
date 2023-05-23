using AutoMapper;
using DocVision.Business.Interfaces;
using DocVision.Business.Models;
using DocVision.Dto.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocVision.WebApi.Controllers.v1
{
    [Route("api/v1/")]
    public class MailController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public MailController(IMapper mapper, IMailService mailService)
        {
            _mapper = mapper;
            _mailService = mailService;
        }


        [HttpGet]
        [Route("GetAllMails")]
        public async Task<IEnumerable<MailDto>> GetAllMails()
        {
            var mailDtoList = await _mailService.GetAllMailsAsync();

            return _mapper.Map<IEnumerable<MailDto>>(mailDtoList);
        }

        [HttpPost]
        [Route("CreateMail")]
        public async Task<IActionResult> CreateMail(MailDto mailRequest)
        {
            var mailBusinessModel = _mapper.Map<MailBusinessModel>(mailRequest);
            await _mailService.CreateMailAsync(mailBusinessModel);

            return Ok();
        }


        [HttpPut]
        [Route("UpdateMail")]
        public async Task<IActionResult> UpdateMail(MailDto mailRequest)
        {
            var mailBusinessModel = _mapper.Map<MailBusinessModel>(mailRequest);
            await _mailService.UpdateMailAsync(mailBusinessModel);

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteMail")]
        public async Task<IActionResult> DeleteMail(Guid id)
        {
            await _mailService.DeleteMailAsync(id);

            return Ok();
        }
    }
}
