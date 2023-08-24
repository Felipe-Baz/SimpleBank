using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace simplebank.Model
{
    public class User
    {
        public int Id { get; set; }
        
        public string Fullname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [MaxLength(8, ErrorMessage = "O campo CEP deve conter 8 caracteres.")]
        [MinLength(8, ErrorMessage = "O campo CEP deve conter 8 caracteres.")]
        public string Cep { get; set; }

        public string Street { get; set; }

        [MaxLength(6, ErrorMessage = "O campo Número deve conter no máximo 6 caracteres.")]
        public string AddressNumber { get; set; }

        public string Complement { get; set; }

        public string District { get; set; }

        public string State { get; set; }

        [MaxLength(40, ErrorMessage = "O campo Cidade deve conter no máximo 40 caracteres.")]
        public string City { get; set; }

        public string Country { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public string Status { get; set; }

        public ICollection<Transfer> SendTransfers { get; set; }
        public ICollection<Transfer> ReceiveTransfers { get; set; }
    }
}