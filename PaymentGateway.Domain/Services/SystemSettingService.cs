using PaymentGateway.Domain.Mappers;
using PaymentGateway.Domain.Reponses;
using PaymentGateway.Domain.Repositories;
using PaymentGateway.Domain.Requests.SystemSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Services
{
    public class SystemSettingService : ISystemSettingService
    {
        private readonly ISystemSettingRepository _systemSettingRepository;
        private readonly ISystemSettingMapper _systemSettingMapper;

        public SystemSettingService(ISystemSettingRepository systemSettingRepository, ISystemSettingMapper systemSettingMapper)
        {
            _systemSettingRepository = systemSettingRepository;
            _systemSettingMapper = systemSettingMapper;
        }

        public async Task<SystemSettingResponse> AddSystemSettingAsync(AddSystemSettingRequest request)
        {
            var systemSetting = _systemSettingMapper.Map(request);
            var result = _systemSettingRepository.Add(systemSetting);
            await _systemSettingRepository.UnitOfWork.SaveChangesAsync();
            return _systemSettingMapper.Map(result);
        }

        public async Task<SystemSettingResponse> EditSystemSettingAsync(EditSystemSettingRequest request)
        {
            var existingRecord = await _systemSettingRepository.GetAsync(request.CustomerId);
            if (existingRecord == null)
            {
                throw new ArgumentException($"System setting ofcustomer with id: {request.CustomerId}, is not present.");
            }
            var paymentTransactionHistory = _systemSettingMapper.Map(request);
            var result = _systemSettingRepository.Update(paymentTransactionHistory);
            await _systemSettingRepository.UnitOfWork.SaveChangesAsync();
            return _systemSettingMapper.Map(result);
        }

        public async Task<IEnumerable<SystemSettingResponse>> GetSystemSettingsAsync()
        {
            var result = await _systemSettingRepository.GetAsync();
            return result.Select(s => _systemSettingMapper.Map(s));
        }

        public async Task<SystemSettingResponse> GetSystemSettingAsync(GetSystemSettingRequest request)
        {
            if (request?.CustomerId == null) throw new ArgumentNullException();
            var result = await _systemSettingRepository.GetAsync(request.CustomerId);
            return _systemSettingMapper.Map(result);
        }
        //public Task<SystemSettingResponse> DeleteSystemSettingByCustomerIdAsync(DeleteSystemSettingRequest request)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
