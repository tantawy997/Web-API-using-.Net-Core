using DevCreed.Models;

namespace DevCreed.Services
{
    public interface IAuthServices
    {
        Task<AuthModel> RegisterAsync(RegisterModel Model);
    }
}
