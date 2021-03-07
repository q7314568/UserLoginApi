using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLoginApi.Helpers.Interface;
using UserLoginApi.Helpers.Valid;
using UserLoginApi.Models;


namespace UserLoginApi.Helpers
{
    /// <summary>
    /// 主要工作:驗證輸入資料的合法性
    /// </summary>
    /// <typeparam name="I">輸入的驗證內容</typeparam>
    /// <typeparam name="O">回傳的結果</typeparam>
    /// <typeparam name="E">存錯誤訊息的Enum/集合</typeparam>
    public class Validation<I, O, E> 
        where I : class
        where O : class
        where E : Enum
    {
        private IValid<I, O, E> _Valid;
        public Validation(IValid<I, O, E> valid)
        {
            this._Valid = valid;
        }
        public O ValidRequest(I userRequest)
        {
            return _Valid.ValidRequest(userRequest);
        }
    }
}
