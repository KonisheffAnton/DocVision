using AutoMapper;
using Microsoft.Extensions.Options;
using DocVision.Business.Interfaces;
using DocVision.DataAccessLayer.Interfaces;
using DocVision.Business.Models;
using DocVision.DataAccessLayer.Entities;

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
            _unitOfWork.MailRepository.Create(mailEntity) ;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<MailBusinessModel>> GetAllMailsAsync()
        { 
           var mailEntityList = await _unitOfWork.MailRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<MailBusinessModel>>(mailEntityList);
        }

        public async Task DeleteMailAsync(Guid id)
        {
            var mailEntity = await _unitOfWork.MailRepository.GetByIdAsync(id);           
            _unitOfWork.MailRepository.Delete(mailEntity);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateMailAsync(MailBusinessModel mailBusinessModel)
        {
            var mailEntity = _mapper.Map<MailEntity>(mailBusinessModel);
            _unitOfWork.MailRepository.Update(mailEntity);

            await _unitOfWork.SaveChangesAsync();
        }
        //public async Task<OpenApplicationBusinessModel> GetOpenApplicationByIdAsync(Guid id)
        //{
        //    var specification = new GetOpenApplicationByIdSpecification(id);
        //    var openApplicationEntities = await _unitOfWork.OpenApplicationRepository.FindWithSpecificationPatternAsync(specification);
        //    var openApplicationEntity = openApplicationEntities.SingleOrDefault();
        //    var openApplicationBusinesModel = _mapper.Map<OpenApplicationBusinessModel>(openApplicationEntity);

        //    return openApplicationBusinesModel;
        //}

        //public async Task<OpenApplicationCodeResult> SendOpenApplicationsAsync(Guid clientId, OpenApplicationBusinessModel openApplication)
        //{
        //    var depositProductBusinessModel = await GetDepositProductBusinessModelAsync(openApplication.DepositProductName);

        //    if (depositProductBusinessModel is null)
        //    {
        //        throw new EntityNotFoundException("DepositProduct", ("DepositProductName", openApplication.DepositProductName));
        //    }

        //    var checkRequestData = CheckRequestData(depositProductBusinessModel, openApplication.Amount, openApplication.DurationMonths);

        //    if (!checkRequestData.IsSucceed)
        //    {
        //        return checkRequestData;
        //    }

        //    var activeOpenApplications = await GetUserOpenApplicationsAsync(clientId);
        //    var checkActiveOpenApplications = CheckActiveOpenApplications(activeOpenApplications, openApplication.DepositProductName);

        //    if (!checkActiveOpenApplications.IsSucceed)
        //    {
        //        return checkActiveOpenApplications;
        //    }

        //    openApplication.Id = Guid.NewGuid();
        //    openApplication.ClientId = clientId;
        //    openApplication.OpenDate = DateTime.UtcNow;
        //    openApplication.CloseDate = DateTime.UtcNow.AddDays(_applicationOptions.Value.OpenApplicationExpirationLongDays);
        //    openApplication.Status = OpenApplicationStatus.Pending;

        //    _unitOfWork.OpenApplicationRepository.Create(_mapper.Map<OpenApplicationEntity>(openApplication));
        //    var saveOpenApplicationToDepositDB = _unitOfWork.SaveChangesAsync();
        //    var openApplicationKafkaMessage = _mapper.Map<OpenApplicationKafka>(openApplication);
        //    var sendOpenApplicationToABS =  _messageBus.SerializeAndSendMessageWithEmptyKeyAsync(openApplicationKafkaMessage, _kafkaProducerOptions.Topics[KafkaTopicKeys.DepositToMasterOpenApplicationKey]);

        //    await Task.WhenAll(saveOpenApplicationToDepositDB, sendOpenApplicationToABS);

        //    return new OpenApplicationCodeResult() { IsSucceed = true };
        //}

        //public async Task<IEnumerable<OpenApplicationBusinessModel>> GetUserOpenApplicationsAsync(Guid clientId)
        //{
        //    var clientOpenApplication = await GetOpenApplicationsByClientIdAndIsActive(clientId);
        //    var activeClientApplication = RemoveExpiredOpenApplications(clientOpenApplication);

        //    return activeClientApplication;
        //}

        //public async Task UpdateOpenApplicationAsync(OpenApplicationBusinessModel openApplication)
        //{
        //    var openApplicationEntity = _mapper.Map<OpenApplicationEntity>(openApplication);
        //    _unitOfWork.OpenApplicationRepository.Update(openApplicationEntity);

        //    await _unitOfWork.SaveChangesAsync();
        //}

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }


        //public async Task<OpenApplicationBusinessModel> GetOpenApplicationByDepositProductNameAndClientIdAsync(Guid clientId, string depositProductName)
        //{
        //    var specification = new GetOpenApplicationByDepositProductNameAndClientIdSpecification(clientId, depositProductName);
        //    var openApplicationEntities = await _unitOfWork.OpenApplicationRepository.FindWithSpecificationPatternAsync(specification);
        //    var openApplicationEntity = openApplicationEntities.SingleOrDefault();

        //    var openApplicationBusinesModel = _mapper.Map<OpenApplicationBusinessModel>(openApplicationEntity);

        //    return openApplicationBusinesModel;
        //}

        //private OpenApplicationCodeResult CheckRequestData(DepositProductBusinessModel depositProductBusinessModel, int amount, int durationMonth)
        //{
        //    if (amount < depositProductBusinessModel.AmountMin || amount > depositProductBusinessModel.AmountMax)
        //    {
        //        return new OpenApplicationCodeResult()
        //        {
        //            IsSucceed = false,
        //            FailReason = OpenDepositApplicationCodeResultType.AmountIsNotCorrect
        //        };
        //    }

        //    if (durationMonth < depositProductBusinessModel.MinDurationMonths || durationMonth > depositProductBusinessModel.MaxDurationMonths)
        //    {
        //        return new OpenApplicationCodeResult()
        //        {
        //            IsSucceed = false,
        //            FailReason = OpenDepositApplicationCodeResultType.DurationMonthIsNotCorrect,
        //        };
        //    }

        //    return new OpenApplicationCodeResult() { IsSucceed = true };
        //}

        //private OpenApplicationCodeResult CheckActiveOpenApplications(IEnumerable<OpenApplicationBusinessModel> openApplicationBusinessModels, string name)
        //{
        //    if (openApplicationBusinessModels.Count() >= _applicationOptions.Value.ActiveOpenApplicationCount)
        //    {
        //        return new OpenApplicationCodeResult()
        //        {
        //            IsSucceed = false,
        //            FailReason = OpenDepositApplicationCodeResultType.NumberOfActiveDepositApplicationsExceeded
        //        };
        //    }

        //    if (openApplicationBusinessModels.Any(oa => oa.DepositProductName == name))
        //    {
        //        return new OpenApplicationCodeResult()
        //        {
        //            IsSucceed = false,
        //            FailReason = OpenDepositApplicationCodeResultType.ActiveOpenApplicationOnDepositProductExists
        //        };
        //    }

        //    return new OpenApplicationCodeResult() { IsSucceed = true };
        //}

        //private async Task<DepositProductBusinessModel> GetDepositProductBusinessModelAsync (string depositProductName)
        //{
        //    var depositProductSpecification = new GetDepositProductByNameIncludingDocumentsSpecification(depositProductName);
        //    var depositProductEntities = await _unitOfWork.DepositProductRepository.FindWithSpecificationPatternAsync(depositProductSpecification, false);
        //    var depositProductEntity = depositProductEntities.SingleOrDefault();

        //    return _mapper.Map<DepositProductEntity, DepositProductBusinessModel>(depositProductEntity);
        //}

        //private async Task<IEnumerable<OpenApplicationBusinessModel>> GetOpenApplicationsByClientIdAndIsActive(Guid clientId)
        //{
        //    var specification = new GetOpenApplicationsByClientIdAndIsActiveSpecification(clientId, true);
        //    var openApplicationEntities = await _unitOfWork.OpenApplicationRepository.FindWithSpecificationPatternAsync(specification);
        //    var openApplicationBusinesModel = _mapper.Map<IEnumerable<OpenApplicationBusinessModel>>(openApplicationEntities);

        //    return openApplicationBusinesModel;
        //}

        //private bool CheckOpenApplicationsForRestrictions(IEnumerable<OpenApplicationBusinessModel> openApplicationBusinessModel, string name)
        //{
        //    return openApplicationBusinessModel.Count() >= _applicationOptions.Value.ActiveOpenApplicationCount ? false :
        //        openApplicationBusinessModel.Any(oa => oa.DepositProductName == name) ? false : true;
        //}

        //private IEnumerable<OpenApplicationBusinessModel> RemoveExpiredOpenApplications(IEnumerable<OpenApplicationBusinessModel> applicationsToCheck)
        //{
        //    var expiredApplications = applicationsToCheck.Where(application => application.CloseDate < DateTime.UtcNow)
        //                                                  .Select(application => { 
        //                                                                           application.IsActive = false;
        //                                                                           return application;
        //                                                                         }
        //                                                         );

        //    var activeApplications = applicationsToCheck.Except(expiredApplications);

        //    var expiredApplicationEntities = _mapper.Map<IEnumerable<OpenApplicationEntity>>(expiredApplications);

        //    _unitOfWork.OpenApplicationRepository.UpdateRange(expiredApplicationEntities);

        //    return activeApplications;
        //}


    }
}