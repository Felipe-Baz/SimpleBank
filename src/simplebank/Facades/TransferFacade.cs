using AutoMapper;
using simplebank.Facades.interfaces;
using simplebank.Model;
using simplebank.Services.Interfaces;

namespace simplebank.Facades
{
    public class TransferFacade : ITransferFacade
    {
        private readonly ITransferService _transferService;
        private readonly IMapper _mapper;

        public TransferFacade(ITransferService transferService, IMapper mapper = null)
        {
            _transferService = transferService;
            _mapper = mapper;
        }


        public async Task<TransferResponseDTO> CreateAsync(TransferCreateDTO transfer)
        {
            var transferMapped = _mapper.Map<Transfer>(transfer);
            var result =  await _transferService.CreateAsync(transfer: transferMapped);
            var resultMapped = _mapper.Map<TransferResponseDTO>(result);
            return resultMapped;
        }

        public async Task<TransferResponseDTO> DetailsAsync(int id)
        {
            var result =  await _transferService.DetailsAsync(id: id);
            var resultMapped = _mapper.Map<TransferResponseDTO>(result);
            return resultMapped;
        }

        public async Task<List<TransferResponseDTO>> ListAsync()
        {
            var result =  await _transferService.ListAsync();
            var resultMapped = _mapper.Map<List<TransferResponseDTO>>(result);
            return resultMapped;
        }
    }
}