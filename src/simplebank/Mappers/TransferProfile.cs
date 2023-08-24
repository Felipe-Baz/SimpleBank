using AutoMapper;
using simplebank.Model;

namespace simplebank.Mappers
{
    public class TransferProfile : Profile
    {
        public TransferProfile()
        {
            CreateUserProfile();
        }

        private void CreateUserProfile()
        {
            CreateMap<TransferCreateDTO, Transfer>();
            CreateMap<Transfer, TransferResponseDTO>();
        }
    }
}