using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITSmartFinance.Models.Models
{
    public class UserUpdateModel
    {
        //Модель обновления пользователя
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
    }
}
