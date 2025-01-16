using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories
{
    public interface ILogTime
    {
        Task<LogTime>AddLogTime(LogTime logTime);
        
    }
}
