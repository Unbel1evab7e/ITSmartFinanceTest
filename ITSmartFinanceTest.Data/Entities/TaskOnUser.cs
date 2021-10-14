using System;
using System.Collections.Generic;
using System.Text;

namespace ITSmartFinanceTest.Data.Entities
{
    public class TaskOnUser
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }

        public virtual User User { get; set; }
        public virtual Task Task { get; set; }
    }
}
