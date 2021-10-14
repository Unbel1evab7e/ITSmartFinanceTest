using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITSmartFinance.Models.Models
{
    public class AdditionTaskToBoardModel
    {
        //Модель добавления задачки на доску
        [Required]
        public Guid BoardId { get; set; }
        [Required]
        public Guid TaskId { get; set; }
    }
}
