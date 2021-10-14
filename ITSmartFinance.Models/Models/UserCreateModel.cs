using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITSmartFinance.Models.Models
{
    public class UserCreateModel
    {
        //Модель создания пользователя
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
    }
}
