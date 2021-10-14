using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITSmartFinance.Models.Models
{
    public class RelationCreateModel
    {
        //Модель добавления связи между доской и пользователем
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid TaskId { get; set; }
    }
}
