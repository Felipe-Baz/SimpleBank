using simplebank.Mappers;

namespace simplebank.UnitTest.Infrastructure.Mappers
{
    public class TransferProfileTest
    {
        public MapperConfiguration MapperConfiguration =
            new(cfg => cfg.AddProfile<TransferProfile>());


        [Fact]
        public void TransferCreateDTOToTransferTest()
        {
            var transferCreateDto = new TransferCreateDTO
            {
                FromUserId = 1,
                ToUserId = 2,
                Amount = 20.0
            };

            var mapper = MapperConfiguration.CreateMapper();
            var transferResponseDTO = mapper.Map<Transfer>(transferCreateDto);

            Assert.Equal(transferResponseDTO.FromUserId, transferCreateDto.FromUserId);
            Assert.Equal(transferResponseDTO.ToUserId, transferCreateDto.ToUserId);
            Assert.Equal(transferResponseDTO.Amount, transferCreateDto.Amount);
        }

        [Fact]
        public void TransferToTransferResponseDTOTest()
        {
            var transfer = new Transfer
            {
                Id = 1,
                FromUserId = 1,
                ToUserId = 2,
                Amount = 20.0,
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var mapper = MapperConfiguration.CreateMapper();
            var transferResponseDTO = mapper.Map<TransferResponseDTO>(transfer);

            Assert.Equal(transferResponseDTO.Id, transfer.Id);
            Assert.Equal(transferResponseDTO.FromUserId, transfer.FromUserId);
            Assert.Equal(transferResponseDTO.ToUserId, transfer.ToUserId);
            Assert.Equal(transferResponseDTO.Amount, transfer.Amount);
            Assert.Equal(transferResponseDTO.CreatedAt, transfer.CreatedAt);
            Assert.Equal(transferResponseDTO.UpdatedAt, transfer.UpdatedAt);
        }
    }
}