using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Twitter_Clone
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter User Name")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Password")]
        public string PassWord { get; set; }

    }
}