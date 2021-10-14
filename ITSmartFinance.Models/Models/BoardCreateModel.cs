using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITSmartFinance.Models.Models
{
    public class BoardCreateModel
    {
        //Модель создания доски
        [Required]
        [MinLength(1)]
        public string Description { get; set; }
    }
}
