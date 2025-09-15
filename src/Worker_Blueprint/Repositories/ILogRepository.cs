using Worker.Models;

namespace Worker.Interfaces
{
    public interface ILogRepository
    {
        Task<List<Log>> GetAllAsync();
        Task AddAsync(Log log);
        Task UpdateAsync(Log log);
        Task DeleteAsync(Log log);
    }
}
