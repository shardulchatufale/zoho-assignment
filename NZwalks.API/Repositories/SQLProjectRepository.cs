using NZwalks.API.Data;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories
{
    public class SQLProjectRepository : IProjecReposiotory
    {
        private readonly NZWalksDBContext dBb;

        public SQLProjectRepository(NZWalksDBContext dBb)
        {
            this.dBb = dBb;
        }

        public async Task<Project> CreateProject(Project project)
        {
            await dBb.Projects.AddAsync(project);
            await dBb.SaveChangesAsync();
            return project;
        }
    }

}
