using System;
using System.Collections.Generic;
using System.Text;

namespace ITSmartFinanceTest.Data.Entities
{
    public class Board
    {
        public Board()
        {
            Tasks = new HashSet<Task>();
        }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
