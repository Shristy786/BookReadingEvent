using Company.Project.Web.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Company.Project.Web.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUser userModel);
        Task<SignInResult>PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();
    }
}