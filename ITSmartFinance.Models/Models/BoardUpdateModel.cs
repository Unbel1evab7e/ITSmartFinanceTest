using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITSmartFinance.Models.Models
{
    public class BoardUpdateModel
    {
        //Модель обновления доски
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Description { get; set; }
    }
}
