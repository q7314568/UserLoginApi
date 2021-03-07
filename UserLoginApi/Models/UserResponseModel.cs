using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLoginApi.Helpers.Interface;
using UserLoginApi.Models.Interface;

namespace UserLoginApi.Models
{
    public class UserResponseModel : IResponseModel
    {
        public int success { get; set; }

        public string token { get; set; }

        public int errorCode { get; set; }

        public string errorMessage { get; set; }
    }
}
