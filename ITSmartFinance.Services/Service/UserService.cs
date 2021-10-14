using AutoMapper;
using ITSmartFinance.Models.Models;
using ITSmartFinance.Services.IService;
using ITSmartFinanceTest.Data;
using ITSmartFinanceTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSmartFinance.Services.Service
{
    public class UserService:IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Сервис по работе с пользователями
        //Создание пользователя
        public async Task<User> CreateUser(UserCreateModel model)
        {
            var User = (await _context.Users.AddAsync(_mapper.Map<User>(model))).Entity;
            await _context.SaveChangesAsync();
            return User;
        }
        //Удаление пользователя
        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                var User = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                _context.Users.Remove(User);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
        //Получение всех пользователей
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.AsNoTracking().Include(x=>x.Tasks).ThenInclude(x=>x.Task).AsEnumerable();

        }
        //Получение пользователя по id
        public async Task<User> GetUser(Guid id)
        {
            return await _context.Users.AsNoTracking().Include(x => x.Tasks).ThenInclude(x => x.Task).FirstOrDefaultAsync(x => x.Id == id);
        }
        //Обновление пользователя
        public async Task<User> UpdateUser(UserUpdateModel model)
        {
            var user = _context.Users.Update(_mapper.Map<User>(model)).Entity;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
