using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simplebank.Model;

namespace simplebank.Services.Interfaces
{
    public interface ITransferService
    {
        public Task<Transfer> CreateAsync(Transfer transfer);

        public Task<List<Transfer>> ListAsync();

        public Task<Transfer> DetailsAsync(int id);
    }
}