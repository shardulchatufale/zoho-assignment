using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories
{
    public interface IAssignProject
    {
        Task<Assignmenent> AssignProject(Assignmenent assignProject);
    }
}
