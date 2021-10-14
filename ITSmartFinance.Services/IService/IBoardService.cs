using ITSmartFinance.Models.Models;
using ITSmartFinanceTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITSmartFinance.Services.IService
{
    public interface IBoardService
    {
        public Task<Board> GetBoard(Guid id);
        public IEnumerable<Board> GetAllBoards();
        public Task<Board> UpdateBoard(BoardUpdateModel model);
        public Task<Board> CreateBoard(BoardCreateModel model);
        public IEnumerable<Board> GetBoardsByTaskCount(int count);
        public double GetAvgTaskCount();
        public Task<bool> DeleteBoard(Guid id);
    }
}
