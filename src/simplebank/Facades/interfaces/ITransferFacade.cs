using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simplebank.Model;

namespace simplebank.Facades.interfaces
{
    public interface ITransferFacade
    {
        public Task<TransferResponseDTO> CreateAsync(TransferCreateDTO transfer);

        public Task<List<TransferResponseDTO>> ListAsync();

        public Task<TransferResponseDTO> DetailsAsync(int id);
    }
}