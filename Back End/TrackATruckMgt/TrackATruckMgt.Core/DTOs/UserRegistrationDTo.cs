using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackATruckMgt.Core.DTOs
{
   public class UserRegistrationDTo
    {
        [Required]
       public string Username { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 5, ErrorMessage = "Your Password must be between 5 and 9 characters")]
      public  string Password { get; set; }
    }
}
