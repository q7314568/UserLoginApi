using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserLoginApi.Models
{
    public class TestModel
    {
        [Required]
        public string value1 { get; set; }

        [Required]
        public string value2 { get; set; }

    }
}
