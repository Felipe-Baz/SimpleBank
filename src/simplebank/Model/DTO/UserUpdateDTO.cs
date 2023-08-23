using System.ComponentModel.DataAnnotations;

namespace simplebank.Model
{
    public class UserUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        
        public string Fullname { get; set; }
        
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Cep { get; set; }

        public string Street { get; set; }

        public string AddressNumber { get; set; }

        public string Complement { get; set; }

        public string District { get; set; }

        public string State { get; set; }

        public string City { get; set; }
        
        public string Country { get; set; }
    }
}