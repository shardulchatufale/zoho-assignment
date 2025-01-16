using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories
{
    public class SQLLogTime : ILogTime
    {
        private readonly NZWalksDBContext dBb;
        public SQLLogTime(NZWalksDBContext dBb)
        {
            this.dBb = dBb;
        }



        public async Task<LogTime> AddLogTime(LogTime logtime)
        {
           
            await dBb.LogTimes.AddAsync(logtime);
            await dBb.SaveChangesAsync();
            return logtime;
        }
    }
}
