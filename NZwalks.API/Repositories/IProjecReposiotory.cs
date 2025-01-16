using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories
{
    public interface IProjecReposiotory
    {
        Task<Project> CreateProject(Project project);

    }
}
