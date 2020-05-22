using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumNUnitExtentNopCommerce
{
    public class GetUserCredentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
         public string DataBase { get; set; }
        // public string[] WronPassword { get; set; }
        public string WrongPassword { get; set; }
        public string ResetPassword { get; internal set; }
    }
}
