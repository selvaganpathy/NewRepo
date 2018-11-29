using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter_Clone
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        [Remote("IsAlreadyExists", "TwitterClone", HttpMethod = "POST", ErrorMessage = "UserId already exists.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please Enter valid Email")]
        [EmailAddress]
        public string Email { get; set; }

        public bool isRegistered { get; set; } = false;


    }
}