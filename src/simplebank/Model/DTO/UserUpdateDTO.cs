using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simplebank.Model
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }
        
        public string Fullname { get; set; }
        
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}