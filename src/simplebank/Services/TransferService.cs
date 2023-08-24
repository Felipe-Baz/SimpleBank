using simplebank.Exceptions;
using simplebank.Extensions;
using simplebank.Model;
using simplebank.Repositories.Interfaces;
using simplebank.Services.Interfaces;

namespace simplebank.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;

        public TransferService(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public async Task<Transfer> CreateAsync(Transfer transfer)
        {
            if (transfer == null)
                throw new ValidationException("User is null.");
            
            Validate(transfer);

            transfer.SetCreated();
            _transferRepository.Add(transfer);
            await _transferRepository.SaveChangesAsync();
            var response = await _transferRepository.GetByIdAsync(transfer.Id);
            return response;
        }

        public async Task<Transfer> DetailsAsync(int id)
        {
            var response = await _transferRepository.GetByIdAsync(id);
            return response;
        }

        public async Task<List<Transfer>> ListAsync()
        {
            var response = await _transferRepository.GetAllAsync();
            return response.ToList();
        }

        private static void Validate(Transfer transfer)
        {
            transfer.ValidateAmount();

            transfer.ValidateFromTo();
        }
    }
}