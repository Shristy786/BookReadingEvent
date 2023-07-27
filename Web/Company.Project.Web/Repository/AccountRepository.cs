using Company.Project.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser>signInManager, RoleManager<IdentityRole>roleManager)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        //public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        //{
        //   await _roleManager.CreateAsync(new IdentityRole { Name="Admin" });
        //    return await _userManager.FindByEmailAsync(email);
        //}



        public async Task<IdentityResult> CreateUserAsync(SignUpUser userModel)
        {
            var user = new ApplicationUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email,
                FullName=userModel.FullName

            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
                return result;
        }
        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
          var result= await _signInManager.PasswordSignInAsync(signInModel.Email,signInModel.Password,signInModel.RememberMe,false);
            return result;
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
