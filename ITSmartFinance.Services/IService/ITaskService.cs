using ITSmartFinance.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITSmartFinance.Services.IService
{
    public interface ITaskService
    {
        public Task<ITSmartFinanceTest.Data.Entities.Task> GetTask(Guid id);
        public IEnumerable<ITSmartFinanceTest.Data.Entities.Task> GetAllTasks();
        public Task<ITSmartFinanceTest.Data.Entities.Task> UpdateTask(TaskUpdateModel model);
        public Task<ITSmartFinanceTest.Data.Entities.Task> CreateTask(TaskCreateModel model);
        public IEnumerable<ITSmartFinanceTest.Data.Entities.Task> GetTaskByUserId(Guid id);
        public Task<bool> DeleteTask(Guid id);
    }
}
