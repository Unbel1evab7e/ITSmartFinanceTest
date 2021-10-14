using System;
using System.Collections.Generic;
using System.Text;

namespace ITSmartFinanceTest.Data.Entities
{
    public class Task
    {
        public Task()
        {
            Users = new HashSet<TaskOnUser>();
        }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public Guid? BoardId { get; set; }

        public virtual Board Board { get; set; }
        public virtual ICollection<TaskOnUser> Users { get; set; }
    }
}
