using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.DTO
{
    public class CustomerDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
      
        public string Email { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Avatar { get; set; }
    }
}
