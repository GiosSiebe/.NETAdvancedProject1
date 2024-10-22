using WineCode.Models;

namespace WineAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
