using Worker.Data;
using Worker.Interfaces;
using Worker.Models;

namespace Worker.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly IDatabaseContext _dbContext;

        public LogRepository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Log>> GetAllAsync()
        {
            return _dbContext.GetAllAsync<Log>();
        }

        public Task AddAsync(Log log)
        {
            return _dbContext.AddAsync(log);
        }

        public Task UpdateAsync(Log log)
        {
            return _dbContext.UpdateAsync(log);
        }

        public Task DeleteAsync(Log log)
        {
            return _dbContext.DeleteAsync(log);
        }
    }
}
