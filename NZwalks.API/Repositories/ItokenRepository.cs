using Microsoft.AspNetCore.Identity;

namespace NZwalks.API.Repositories
{
    public interface ItokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
       
    }
}
