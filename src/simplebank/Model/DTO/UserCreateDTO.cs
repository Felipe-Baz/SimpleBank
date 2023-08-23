using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace simplebank.Model
{
    public class UserCreateDTO
    {
        
        [Required(ErrorMessage = "O campo Nome completo é obrigatório!")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Número de telefone é obrigatório!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório!")]
        [MaxLength(8, ErrorMessage = "O campo CEP deve conter 8 caracteres.")]
        [MinLength(8, ErrorMessage = "O campo CEP deve conter 8 caracteres.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo Rua é obrigatório!")]
        public string Street { get; set; }

        [Required]
        [MaxLength(6, ErrorMessage = "O campo Número deve conter no máximo 6 caracteres.")]
        public string AddressNumber { get; set; }

        public string Complement { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório!")]
        public string District { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório!")]
        public string State { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório!")]
        [MaxLength(40, ErrorMessage = "O campo Cidade deve conter no máximo 40 caracteres.")]
        public string City { get; set; }

        [Required(ErrorMessage = "O campo Pais é obrigatório!")]
        public string Country { get; set; }
    }
}