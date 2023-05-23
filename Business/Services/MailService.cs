using AutoMapper;
using DocVision.Business.Interfaces;
using DocVision.Business.Models;
using DocVision.DataAccessLayer.Entities;
using DocVision.DataAccessLayer.Interfaces;

namespace DocVision.Business.Services
{
    public class MailService : IMailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MailService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateMailAsync(MailBusinessModel mailBusinessModel)
        {
            var mailEntity = _mapper.Map<MailEntity>(mailBusinessModel);
            _unitOfWork.MailRepository.Create(mailEntity);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<MailBusinessModel>> GetAllMailsAsync()
        {
            var mailEntityList = await _unitOfWork.MailRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<MailBusinessModel>>(mailEntityList);
        }

        public async Task DeleteMailAsync(MailBusinessModel mailBusinessModel)
        {
            var mailEntity = _mapper.Map<MailEntity>(mailBusinessModel);
            _unitOfWork.MailRepository.Delete(mailEntity);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateMailAsync(MailBusinessModel mailBusinessModel)
        {
            var mailEntity = _mapper.Map<MailEntity>(mailBusinessModel);
            _unitOfWork.MailRepository.Update(mailEntity);

            await _unitOfWork.SaveChangesAsync();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

    }
}