using AutoMapper;
using DocVision.Business.Interfaces;
using DocVision.DataAccessLayer.Interfaces;

namespace DocVision.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        //public async Task<IEnumerable<AccountBusinessModel>> GetClientActiveAccountsAsync(Guid clientId)
        //{
        //    var specification = new GetAccountByClientIdAndIsActiveSpecification(clientId, true);
        //    var activeAccountEntities = await _unitOfWork.AccountRepository.FindWithSpecificationPatternAsync(specification, false);
        //    var activeAccountBusinessModels = _mapper.Map<IEnumerable<AccountBusinessModel>>(activeAccountEntities);

        //    return activeAccountBusinessModels;
        //}

        //public async Task<AccountBusinessModel> GetClientAccountByNumberAsync(string accountNumber, Guid clientId)
        //{
        //    var specification = new GetAccountByNumberAndClientIdSpecification(accountNumber, clientId);
        //    var accounts = await _unitOfWork.AccountRepository.FindWithSpecificationPatternAsync(specification);
        //    var account = _mapper.Map<AccountBusinessModel>(accounts.SingleOrDefault());

        //    return account;
        //}
    }
}
