using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLoginApi.Helpers.Interface;

namespace UserLoginApi.Models
{
    public class UserRequestModel
    {
        public string username { get; set; }

        public string password { get; set; }
    }
}
