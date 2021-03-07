using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLoginApi.Extensions;
using UserLoginApi.Helpers.Enums;
using UserLoginApi.Helpers.Interface;
using UserLoginApi.Helpers.Logging;
using UserLoginApi.Models;

namespace UserLoginApi.Helpers.Valid
{
    /// <summary>
    /// 負責:驗證UserLogin合法性，如不通過回傳指定錯誤訊息
    /// </summary>
    public class UserLoginValid : IValid<UserRequestModel, UserResponseModel, Enum>
    {
        /// <summary>
        /// 驗證傳入的UserRequestModel
        /// </summary>
        /// <param name="request">登入者資料</param>
        /// <returns>回傳驗證結果</returns>
        public UserResponseModel ValidRequest(UserRequestModel request)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Debug("ValidRequest Start");
            try
            {
                if (request is { username: null or "", password: null or "" })
                {
                    return GetErrorResponse(UserLoginErrorResultEnum.MissingLoginInfo);
                }

                if (request is not { username: "peter", password: "1234567" })
                {
                    return GetErrorResponse(UserLoginErrorResultEnum.ErrorLoginInfo);
                }
            }
            catch (Exception)
            {
                return GetErrorResponse(UserLoginErrorResultEnum.UnknowError);
            }
            return Success();
        }
        
        /// <summary>
        /// 回傳驗證成功結果
        /// </summary>
        /// <returns></returns>
        public UserResponseModel Success()
        {
            return new UserResponseModel { success = (int)UserLoginSuccessResultEnum.success, token = Guid.NewGuid().ToString() };
        }

        /// <summary>
        /// 回傳驗證失敗結果
        /// </summary>
        /// <param name="errorEnum">傳入UserLoginErrorResultEnum的屬性以判斷是哪種錯誤</param>
        /// <returns>回傳驗證失敗的結果</returns>
        public UserResponseModel GetErrorResponse(Enum errorEnum)
        {
            var dictMethod = GetErrorResponseDictMethod();
            return dictMethod[errorEnum.ToInteger()](errorEnum);

            //return dictMethod[errorEnum.GetValue<UserLoginErrorResultEnum>()](UserLoginSuccessResultEnum.test);

        }

        /// <summary>
        /// 供GetErrorResponseDict判定要回傳的結果
        /// </summary>
        /// <param name="errorEnum"></param>
        /// <returns></returns>
        public UserResponseModel ErrorResponseDictMethod(Enum errorEnum)
        {
            UserResponseModel userResponse = new UserResponseModel();

            userResponse.success = (int)UserLoginSuccessResultEnum.fail;
            userResponse.errorCode = errorEnum.ToInteger();
            userResponse.errorMessage = errorEnum.GetDescription();
            return userResponse;
        }

        /// <summary>
        /// 利用Dictionary存入UserLoginSuccessResultEnum及ErrorResponseDictMethod以判斷錯誤的類型
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Func<Enum, UserResponseModel>> GetErrorResponseDictMethod()
        {
            var methods = new Dictionary<int, Func<Enum, UserResponseModel>>();
            foreach (int value in Enum.GetValues(typeof(UserLoginErrorResultEnum)))
            {
                methods.Add(value, ErrorResponseDictMethod);
            }
            return methods;
        }
    }
}
