using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserLoginApi.Helpers;
using UserLoginApi.Helpers.Interface;
using UserLoginApi.Helpers.Valid;
using UserLoginApi.Models;

namespace UserLoginApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into UserController");
        }

        [HttpPost]
        public UserResponseModel Login(UserRequestModel userRequest)
        {
            _logger.LogInformation("Logining Start");
            UserLoginValid userLoginValid = new();
            Validation<UserRequestModel, UserResponseModel, Enum> valid = new(userLoginValid);
            return valid.ValidRequest(userRequest);
        }

        [HttpGet]
        public string Test()
        {
            UserController t = new(_logger);

            TestModel tm = new() {  };
            var result = t.Test2(tm);

            return "Y";
        }
        [HttpGet]
        public string Test2(TestModel tm)
        {

            CustomModelValidHelper<TestModel> cm = new CustomModelValidHelper<TestModel>();

            var result= cm.ValidModel(tm);

            if (result.Item1)
            {
                return "Y";
            }
       
            return "N";
        }


        //[HttpGet]
        //public string getUrl()
        //{
        //    //return Url.Content("/");
        //    return $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
        //}
    }
}
