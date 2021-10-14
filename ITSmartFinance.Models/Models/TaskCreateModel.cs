using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITSmartFinance.Models.Models
{
    public class TaskCreateModel
    {
        //Модель создания таски
        [Required]
        [MinLength(1)]
        public string Description { get; set; }
        public Guid? BoardId { get; set; }
    }
}
