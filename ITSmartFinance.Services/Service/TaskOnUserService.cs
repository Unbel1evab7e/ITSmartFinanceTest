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
    public class TaskOnUserService : ITaskOnUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TaskOnUserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Сервис управления связями между задачками и пользователями
        //Создание связи
        public async Task<bool> AddRelation(RelationCreateModel model)
        {
            try
            {
                await _context.TasksOnUsers.AddAsync(_mapper.Map<TaskOnUser>(model));
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Удаление связи
        public async Task<bool> DeleteRelation(Guid id)
        {
            try
            {
                var entity = await _context.TasksOnUsers.FirstOrDefaultAsync(x => x.Id == id);
                _context.TasksOnUsers.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Получение всех связей
        public IEnumerable<TaskOnUser> GetAllEntities()
        {
            return _context.TasksOnUsers.Include(x=>x.Task).Include(x=>x.User).AsNoTracking().AsEnumerable();
        }
    }
}
