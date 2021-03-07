using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserLoginApi.Helpers.Interface
{
    /// <summary>
    /// 供驗證使用的介面
    /// </summary>
    /// <typeparam name="I">輸入的資料型態</typeparam>
    /// <typeparam name="O">回傳的結果型態</typeparam>
    /// <typeparam name="E">存錯誤訊息的Enum型態</typeparam>
    public interface IValid<I, O, E> 
        where I : class
        where O : class
        where E : Enum
    {
        /// <summary>
        /// 驗證輸入的資料
        /// </summary>
        /// <param name="request">輸入的資料</param>
        /// <returns></returns>
        public O ValidRequest(I request);

        /// <summary>
        /// 回傳驗證成功
        /// </summary>
        /// <returns></returns>
        public O Success();

        /// <summary>
        /// 回傳驗證失敗的錯誤代碼及訊息
        /// </summary>
        /// <param name="errorResultEnum"></param>
        /// <returns></returns>
        public O GetErrorResponse(E errorResultEnum);
    }
}
