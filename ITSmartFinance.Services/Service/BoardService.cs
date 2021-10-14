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
    public class BoardService : IBoardService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BoardService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Сервис работы с досками
        //Создание доски
        public async Task<Board> CreateBoard(BoardCreateModel model)
        {
            var board = (await _context.Boards.AddAsync(_mapper.Map<Board>(model))).Entity;
            await _context.SaveChangesAsync();
            return board;
        }
        //Удаление доски
        public async Task<bool> DeleteBoard(Guid id)
        {
            try
            {
                var board = await _context.Boards.FirstOrDefaultAsync(x => x.Id == id);
                _context.Boards.Remove(board);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
        //Получение всех досок
        public IEnumerable<Board> GetAllBoards()
        {
            return _context.Boards.AsNoTracking().Include(x => x.Tasks).AsEnumerable();
        }
        //Получение доски по id
        public async Task<Board> GetBoard(Guid id)
        {
            return await _context.Boards.AsNoTracking().Include(x=>x.Tasks).FirstOrDefaultAsync(x => x.Id == id);
        }
        //Обновление доски
        public async Task<Board> UpdateBoard(BoardUpdateModel model)
        {
            var board = _context.Boards.Update(_mapper.Map<Board>(model)).Entity;
            await _context.SaveChangesAsync();
            return board;
        }
        //Получение n-ого количества досок с самым большим количеством задачек
        public IEnumerable<Board> GetBoardsByTaskCount(int count)
        {
            return _context.Boards.AsNoTracking().Include(x => x.Tasks).OrderBy(x=>x.Tasks.Count).Reverse().Take(count).AsEnumerable();
        }
        //Получение среднего количества задачек в доске
        public double GetAvgTaskCount()
        {
            double boardsCount = _context.Boards.Count();
            double tasksCount = 0;
            foreach (var item in _context.Boards.Include(x=>x.Tasks))
            {
                tasksCount += item.Tasks.Count;
            }
            return tasksCount / boardsCount;
        }
    }
}
