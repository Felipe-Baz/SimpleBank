using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simplebank.Model
{
    public class UserResponseDTO
    {
        public int Id { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}