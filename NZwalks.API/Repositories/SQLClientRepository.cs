using NZwalks.API.Data;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories
{
    public class SQLClientRepository : IclientRepository
    {
        private readonly NZWalksDBContext dBb;

        public SQLClientRepository(NZWalksDBContext dBb)
        {
            this.dBb = dBb;
        }

        public async Task<Client> CreateClient(Client client)
        {
            await dBb.Clients.AddAsync(client);
            await dBb.SaveChangesAsync();
            return client;


        }
    }
}
