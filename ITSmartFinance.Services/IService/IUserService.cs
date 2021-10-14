using ITSmartFinance.Models.Models;
using ITSmartFinanceTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITSmartFinance.Services.IService
{
    public interface IUserService
    {
        public Task<User> GetUser(Guid id);
        public IEnumerable<User> GetAllUsers();
        public Task<User> UpdateUser(UserUpdateModel model);
        public Task<User> CreateUser(UserCreateModel model);
        public Task<bool> DeleteUser(Guid id);
    }
}
