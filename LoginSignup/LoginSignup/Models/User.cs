using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoginSignup.Models
{
    public class User
    {
        [Required]
        [StringLength(255)]
        [Display(Name="Email")]
        [EmailAddress]
        public string username { get; set; }
        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [Required]
        public string NickName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]  
        public DateTime BirthDate { get; set; }

       // public int Age { get; set; }



    }


    
}