using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories
{
    public interface IclientRepository
    {
        Task<Client> CreateClient(Client client);


    }
}
