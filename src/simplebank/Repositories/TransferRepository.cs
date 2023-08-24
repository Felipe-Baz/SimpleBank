using simplebank.Data;
using simplebank.Model;
using simplebank.Repositories.Interfaces;

namespace simplebank.Repositories
{
    public class TransferRepository : RepositoryBase<Transfer>, ITransferRepository
    {
        public TransferRepository(DBContext context) : base(context)
        {
        }
    }
}