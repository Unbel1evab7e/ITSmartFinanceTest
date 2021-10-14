using AutoMapper;
using ITSmartFinance.Models.Models;
using ITSmartFinance.Services.IService;
using ITSmartFinanceTest.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSmartFinance.Services.Service
{
    public class TaskService:ITaskService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TaskService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Сервис по работе с задачками
        //Создание задачки
        public async Task<ITSmartFinanceTest.Data.Entities.Task> CreateTask(TaskCreateModel model)
        {
            var Task = (await _context.Tasks.AddAsync(_mapper.Map<ITSmartFinanceTest.Data.Entities.Task>(model))).Entity;
            await _context.SaveChangesAsync();
            return Task;
        }
        //Удаление задачки
        public async Task<bool> DeleteTask(Guid id)
        {
            try
            {
                var Task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
                _context.Tasks.Remove(Task);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
        //Получение всех задачек
        public  IEnumerable<ITSmartFinanceTest.Data.Entities.Task> GetAllTasks()
        {
            
            return _context.Tasks.Include(x => x.Board).ThenInclude(x => x.Tasks).Include(x=>x.Users).ThenInclude(x => x.User).AsEnumerable().OrderBy(x=>x.CreatedTime).Reverse();
        }
        //Получение задачки по id 
        public async Task<ITSmartFinanceTest.Data.Entities.Task> GetTask(Guid id)
        {
            return await _context.Tasks.Include(x => x.Board).ThenInclude(x => x.Tasks).Include(x => x.Users).ThenInclude(x=>x.User).FirstOrDefaultAsync(x => x.Id == id);
        }
        //Обновление задачки
        public async Task<ITSmartFinanceTest.Data.Entities.Task> UpdateTask(TaskUpdateModel model)
        {
            model.CreatedTime = (await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == model.Id)).CreatedTime;
            var task = _context.Tasks.Update(_mapper.Map<ITSmartFinanceTest.Data.Entities.Task>(model)).Entity;
            await _context.SaveChangesAsync();
            return task;
        }
        //Получение задачек по id пользователя
        public IEnumerable<ITSmartFinanceTest.Data.Entities.Task> GetTaskByUserId(Guid id)
        {
            return  _context.TasksOnUsers.AsNoTracking().Include(x=>x.Task).ThenInclude(x=>x.Users).ThenInclude(x=>x.User).Where(X=>X.UserId==id).Select(X=>X.Task).AsEnumerable();
        }
    }
}
