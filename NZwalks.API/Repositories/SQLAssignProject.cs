using NZwalks.API.Data;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories
{
    public class SQLAssignProject : IAssignProject
    {
        private readonly NZWalksDBContext dBb;

        public SQLAssignProject(NZWalksDBContext dBb)
        {
            this.dBb = dBb;
        }
       public async Task<Assignmenent> AssignProject(Assignmenent assignProject)
        {
            await dBb.Assignmenents.AddAsync(assignProject);
            dBb.SaveChanges();
            return assignProject;
        }
    }
}
