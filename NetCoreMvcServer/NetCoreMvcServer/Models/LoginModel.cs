using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login_User_Cannot_Empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Login_Passwork_Cannot_Empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
