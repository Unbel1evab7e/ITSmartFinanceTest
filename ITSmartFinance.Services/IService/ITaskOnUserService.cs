using ITSmartFinance.Models.Models;
using ITSmartFinanceTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITSmartFinance.Services.IService
{
    public interface ITaskOnUserService
    {
        public IEnumerable<TaskOnUser> GetAllEntities();
        public Task<bool> AddRelation(RelationCreateModel model);
        public Task<bool> DeleteRelation(Guid id);

    }
}
