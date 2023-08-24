namespace simplebank.Model
{
    public class TransferResponseDTO
    {
        public int Id { get; set; }

        public int FromUserId { get; set; }

        public UserResponseDTO FromUser { get; set; }

        public int ToUserId { get; set; }

        public UserResponseDTO ToUser { get; set; }

        public double Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}