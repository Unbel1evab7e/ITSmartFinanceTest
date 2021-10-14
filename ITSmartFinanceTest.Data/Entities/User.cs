using System;
using System.Collections.Generic;
using System.Text;

namespace ITSmartFinanceTest.Data.Entities
{
    public class User
    {
        public User()
        {
            Tasks = new HashSet<TaskOnUser>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TaskOnUser> Tasks { get; set; }
    }
}
