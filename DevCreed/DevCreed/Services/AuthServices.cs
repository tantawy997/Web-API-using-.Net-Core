using DevCreed.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace DevCreed.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<User> _userManager;
        public AuthServices(UserManager<User> userManager)
        {
            _userManager = userManager ;

        }
        public async Task<AuthModel> RegisterAsync(RegisterModel Model)
        {
            if (await _userManager.FindByEmailAsync(Model.email) is not null)
            {
                return new AuthModel { Message = "email is already registered!"};
            };

            if (await _userManager.FindByNameAsync(Model.UserName) is not null)
            {
                return new AuthModel { Message = "UserName is already registered!" };

            }
            var user = new User()
            {
                 UserName = Model.UserName,
                 Email = Model.email,
                 FirstName = Model.FirstName,
                 LastName = Model.LastName,
            };

            var result = await _userManager.CreateAsync(user,Model.password);

            if (!result.Succeeded)
            {
                var error = string.Empty;
                foreach (var item in result.Errors)
                {
                    error += $"{item.Description},".Trim();
                }

                return new AuthModel { Message = error};
            }

            await _userManager.AddToRoleAsync(user, "User");

            return new AuthModel{ Message = "I still did not finish"};
        }
    }
}
