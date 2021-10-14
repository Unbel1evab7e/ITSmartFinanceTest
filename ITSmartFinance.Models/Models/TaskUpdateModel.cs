using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITSmartFinance.Models.Models
{
    public class TaskUpdateModel
    {
        //Модель обновления таски
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Description { get; set; }
        public Guid? BoardId { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
