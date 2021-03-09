using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserLoginApi.Helpers
{
    public class CustomModelValidHelper<T>
    {
        /// <summary>
        /// 獨立傳入model及model型態判斷model Validation是否通過，回傳所有驗證結果。
        /// </summary>
        /// <param name="model">傳入欲驗證的model</param>
        /// <returns>驗證結果</returns>
        public Tuple<bool, List<ValidationResult>> ValidModel(T model)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);


            return new Tuple<bool, List<ValidationResult>>(isModelStateValid, results);

        }
    }
}
