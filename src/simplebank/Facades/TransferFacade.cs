using AutoMapper;
using simplebank.Facades.interfaces;
using simplebank.Model;
using simplebank.Services.Interfaces;

namespace simplebank.Facades
{
    public class TransferFacade : ITransferFacade
    {
        private readonly ITransferService _transferService;
        private readonly IUserFacade _userFacade;
        private readonly IMapper _mapper;

        public TransferFacade(
            ITransferService transferService, 
            IMapper mapper = null,
            IUserFacade userFacade = null
        ) {
            _transferService = transferService;
            _mapper = mapper;
            _userFacade = userFacade;
        }


        public async Task<TransferResponseDTO> CreateAsync(TransferCreateDTO transfer)
        {
            var transferMapped = _mapper.Map<Transfer>(transfer);
            var result = await _transferService.CreateAsync(transfer: transferMapped);
            var resultMapped = _mapper.Map<TransferResponseDTO>(result);
            SetUsers(resultMapped);

            return resultMapped;
        }


        public async Task<TransferResponseDTO> DetailsAsync(int id)
        {
            var result =  await _transferService.DetailsAsync(id: id);
            var resultMapped = _mapper.Map<TransferResponseDTO>(result);
            SetUsers(resultMapped);
            return resultMapped;
        }

        public async Task<List<TransferResponseDTO>> ListAsync()
        {
            var result = await _transferService.ListAsync();
            var resultMapped = _mapper.Map<List<TransferResponseDTO>>(result);
            foreach (var user in resultMapped)
            {
                SetUsers(user);
            }
            return resultMapped;
        }

        private void SetUsers(TransferResponseDTO resultMapped)
        {
            if (resultMapped != null && (resultMapped.ToUser == null || resultMapped.FromUser == null))
            {
                var fromUser = _userFacade.GetUserByIdWithDeleted(resultMapped.FromUserId);
                var toUser = _userFacade.GetUserByIdWithDeleted(resultMapped.ToUserId);
                resultMapped.ToUser = toUser;
                resultMapped.FromUser = fromUser;
            }
        }
    }
}