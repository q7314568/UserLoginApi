using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLoginApi.Helpers;
using UserLoginApi.Helpers.Interface;
using UserLoginApi.Helpers.Valid;
using UserLoginApi.Models;

namespace UserLoginApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into UserController");
        }
        [Route("[controller]/[action]")]
        [HttpPost]
        public UserResponseModel Login(UserRequestModel userRequest)
        {
            _logger.LogInformation("Logining Start");
            UserLoginValid userLoginValid = new();
            Validation<UserRequestModel, UserResponseModel, Enum> valid = new(userLoginValid);
            return valid.ValidRequest(userRequest);
        }

    }
}
