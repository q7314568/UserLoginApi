using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UserLoginApi.Helpers.Enums
{
    public enum UserLoginErrorResultEnum
    {
        [Description("缺少帳號密碼")]
        MissingLoginInfo=-1,
        [Description("帳號密碼錯誤")]
        ErrorLoginInfo = -2,

        [Description("未知錯誤")]
        UnknowError = -3,
    }
}
